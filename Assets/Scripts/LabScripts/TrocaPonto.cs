using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrocaPonto : MonoBehaviour
{

    [SerializeField] private TextMeshPro pontos;
    int pontuacao = 0;

    public void TrocarPontos (int n, bool somar)
    {
        if (somar)
        {
            pontuacao += n;
        }
        else
        {
            pontuacao -= n;
        }
    }

   

    // Update is called once per frame
    void Update()
    {
        pontos.text = pontuacao.ToString();
    }
}
