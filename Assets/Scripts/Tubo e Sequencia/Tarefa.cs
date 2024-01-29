using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tarefa : MonoBehaviourPunCallbacks
{
    public SequenciaAtiva tubo;
     

    private List<int> sequencia1 = new List<int>() { 1, 2, 4, 2, 3, 2, 4, 3, 1 };
    private List<int> sequencia2 = new List<int>() { 2, 4, 3, 1, 1, 3, 2, 2, 4 };

    public void inserirSequencia()
    {
        this.photonView.RPC("trocarSequencia", RpcTarget.All);
    }

    [PunRPC]
    void trocarSequencia()
    {
        tubo.sequencia.Clear();
      

        if (SetGameConfig.SEQUENCIA1)
        {
            tubo.sequencia = sequencia1;                  
        }
        else
        {
            tubo.sequencia = sequencia2;     
        }

        tubo.updateProximo();      

    }



}
