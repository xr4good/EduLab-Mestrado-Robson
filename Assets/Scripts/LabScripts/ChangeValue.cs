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

    public void AumentaValor()
    {
        if(slider.value < 64 )
        {
            int value = (int)slider.value;
            value++;
            slider.value = value;
            text.text = value.ToString();
           
        }
        
    }

    public void DiminuiValor()
    {
        if(slider.value > 0)
        {
            int value = (int)slider.value;
            value--;
            slider.value = value;
            text.text = value.ToString();
        }
        
    }
}
