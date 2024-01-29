using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcenderLampada : MonoBehaviourPunCallbacks
{
    public Material lampadaApagada;
    public Material lampadaAcesa;
    StatementSender statementSender;
    GameDefinitions gameDefinitions;
    void Start()
    {
       statementSender = GameObject.FindObjectOfType<StatementSender>();
        gameDefinitions = FindObjectOfType<GameDefinitions>();
    }

    public void Acender()
    {
        this.photonView.RPC("AcenderLuz", RpcTarget.All);

        if (gameDefinitions.SEQUENCIA1)
        {
            statementSender.SendStament("Solicitou Dica / Humano", "Sequencia1", true, false);
        }
        else
        {
            statementSender.SendStament("Solicitou Dica / Humano", "Sequencia2", true, false);
        }
    }

    [PunRPC]
     IEnumerator AcenderLuz()
    {
            transform.GetComponent<MeshRenderer>().material = lampadaAcesa;
            yield return new WaitForSeconds(5);
             transform.GetComponent<MeshRenderer>().material = lampadaApagada;
    }


}
