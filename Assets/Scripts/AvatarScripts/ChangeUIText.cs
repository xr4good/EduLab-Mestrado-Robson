using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeUIText : MonoBehaviour
{
    public TextMeshProUGUI ui;
    public Slider slider;


    public void changeTexto()
    {
        ui.text = slider.value.ToString();
    }
}

