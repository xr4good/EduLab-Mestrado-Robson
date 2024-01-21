using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcenderLampada : MonoBehaviour
{
    public Material lampadaApagada;
    public Material lampadaAcesa;
    public GameObject luz;
    private bool isAceso = false;

    public StatementSender statementSender;

    public void Acender()
    {
        if (!isAceso)        
        {
            transform.GetComponent<MeshRenderer>().material = lampadaAcesa;
            luz.SetActive(true);
            isAceso = true;

            if (SetGameConfig.SEQUENCIA1)
            {
                statementSender.SendStament("Solicitou Dica / Humano", "Sequencia1", true, false);
            }
            else
            {
                statementSender.SendStament("Solicitou Dica / Humano", "Sequencia2", true, false);
            }

        }
    }

    public void Apagar()
    {
        if (isAceso)
        {
            transform.GetComponent<MeshRenderer>().material = lampadaApagada;
            luz.SetActive(false);
            isAceso = false;
        }        
    }

}
