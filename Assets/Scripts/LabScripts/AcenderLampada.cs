using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcenderLampada : MonoBehaviourPunCallbacks
{
    public Material lampadaApagada;
    public Material lampadaAcesa;
    public GameObject luz;
    private bool isAceso = false;

    StatementSender statementSender;

    void Start()
    {
       statementSender = GameObject.FindObjectOfType<StatementSender>(); 
    }

    public void Acender()
    {
        this.photonView.RPC("AcenderLuz", RpcTarget.All);

        if (SetGameConfig.SEQUENCIA1)
        {
            statementSender.SendStament("Solicitou Dica / Humano", "Sequencia1", true, false);
        }
        else
        {
            statementSender.SendStament("Solicitou Dica / Humano", "Sequencia2", true, false);
        }
    }

    [PunRPC]
     void AcenderLuz()
    {
        if (!isAceso)        
        {
            transform.GetComponent<MeshRenderer>().material = lampadaAcesa;
            luz.SetActive(true);
            isAceso=true;

        }
    }

    public void Apagar()
    {
                 this.photonView.RPC("ApagarLuz", RpcTarget.All);
    }

    [PunRPC]
    void ApagarLuz()
    {
        foreach ( GameObject obj in GameObject.FindGameObjectsWithTag("Lamp"))
        {

            if (isAceso)
            {
                obj.transform.GetComponent<MeshRenderer>().material = lampadaApagada;
                obj.GetComponent<AcenderLampada>().luz.SetActive(false);
                obj.GetComponent<AcenderLampada>().isAceso = false;
            }
        }
        
    }

}
