using Photon.Pun.UtilityScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeValue : MonoBehaviour
{
    public Text text;
    public Slider slider;

    public void TrocaValor()
    {
        text.text = slider.value.ToString();
    }
}
