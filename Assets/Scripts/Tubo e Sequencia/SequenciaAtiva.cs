using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SequenciaAtiva : MonoBehaviourPunCallbacks
{
    public List<int> sequencia = new List<int>();
    [SerializeField] private int proximo;
    public GameObject tubo;
    public Material materialConcluido;
    private TimeCounter timeCounter;
    private int pos = 0;
    public bool concluido = false;
    public GameObject painelFinal;

    private List<int> sequencia1 = new List<int>() { 1, 2, 4, 2, 3, 2, 4, 3, 1 };
    private List<int> sequencia2 = new List<int>() { 2, 4, 3, 1, 1, 3, 2, 2, 4 };

    

    GameDefinitions gameDefinitions;
    private void Start()
    {
        gameDefinitions = FindObjectOfType<GameDefinitions>();
        timeCounter = GameObject.FindObjectOfType<TimeCounter>();        
        this.photonView.RPC("trocarSequencia", RpcTarget.All);
        
    }
         
    

    [PunRPC]
    void trocarSequencia()
    {
        //yield return new WaitForSeconds(1);
        if (gameDefinitions.SEQUENCIA1)
        {
            this.sequencia = sequencia1;
        }
        else
        {
            this.sequencia = sequencia2;
        }
        proximo = sequencia.ElementAt(pos);

    }

    public int getProximo()
    {
        return proximo;
    }


    public void updateProximo()
    {
        this.photonView.RPC("updateProximoGeral", RpcTarget.All);
    }

    [PunRPC]
    void updateProximoGeral()
    {
        if (pos < sequencia.Count)
        {
            proximo = sequencia.ElementAt(pos);
            pos++;

        }
        else
        {
            tubo.GetComponent<Renderer>().material = materialConcluido;
            concluido=true;
            proximo = 13;
            timeCounter.StopCounter();
            this.photonView.RPC("ChamarPainelFinal", RpcTarget.All);

        }
    }

    [PunRPC]
    void ChamarPainelFinal()
    {
        painelFinal.SetActive(true);
    }



}
