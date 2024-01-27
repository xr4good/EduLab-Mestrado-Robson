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

    public List<GameObject> tuboList = new List<GameObject>();
    private void Start()
    {
        timeCounter = GameObject.FindObjectOfType<TimeCounter>();
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
            proximo = 7;
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
