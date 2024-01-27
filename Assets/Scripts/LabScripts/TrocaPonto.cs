using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrocaPonto : MonoBehaviourPunCallbacks
{

    [SerializeField] private TextMeshPro pontos;
    int pontuacao = 0;

    public void TrocarPontos(int n, bool somar)
    {
        this.photonView.RPC("TrocarPontosGeral", RpcTarget.All, n, somar);
    }

    [PunRPC]
    void TrocarPontosGeral (int n, bool somar)
    {
        if (somar)
        {
            pontuacao += n;
        }
        else
        {
            pontuacao -= n;
        }

        pontos.text = pontuacao.ToString();
    }

   

}
