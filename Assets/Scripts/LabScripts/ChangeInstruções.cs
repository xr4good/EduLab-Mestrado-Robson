using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeInstruções : MonoBehaviour
{
    private GameDefinitions game;
    public TextMeshPro lousa;

    void Start()
    {
        game = FindObjectOfType<GameDefinitions>();
        if (game.JUNTO)
        {
            lousa.text = "Vocês deverão encontrar uma sequencia de nove cores representada por bolas de cores distintas. Juntos colocarão no tubo à " +
                "esquerda da caixa as nove bolas.  Utilizem o botão vermelho para solicitar dicas a um professor. Caso " +
                "acerte a cor que deverá entrar no tubo, ganhará 10 pontos, se errar perderá 10 pontos. Conclua este desafio com no mínimo 30 pontos.";
        }
        else
        {
            lousa.text = "Vocês deverão encontrar uma sequencia de nove cores representada por bolas de cores distintas. Cada um, em sua bancada, colocará no tubo à " +
                "esquerda da caixa as nove bolas.  Utilizem o botão vermelho para solicitar dicas a um professor. Caso " +
                "acerte a cor que deverá entrar no tubo, ganhará 10 pontos, se errar perderá 10 pontos. Conclua este desafio com no mínimo 30 pontos.";
        }
    }
    
}
