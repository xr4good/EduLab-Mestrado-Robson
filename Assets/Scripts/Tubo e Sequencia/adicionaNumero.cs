using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class adicionaNumero : MonoBehaviour
{
    public TextMeshProUGUI text;
    public SetPlayer setPlayer;
    public int n;

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
