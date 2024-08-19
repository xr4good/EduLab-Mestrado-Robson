using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class adicionaNumero : MonoBehaviour
{
    public TextMeshProUGUI text;
    public SetPlayer setPlayer;
    int n = 0;

    public void aumentar()
    {
        if (n < 64)
        {
            n++;
        }
        text.text = n.ToString();
        setPlayer.ChangePlayer(n);
    }

    public void diminuir()
    {
        if (n > 0)
        {
            n--;
        }
        text.text = n.ToString();
        setPlayer.ChangePlayer(n);
    }

}
