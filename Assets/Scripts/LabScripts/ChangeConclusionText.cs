using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeConclusionText : MonoBehaviour
{
    public TextMeshProUGUI text; 
    GameDefinitions gameDefinitions;
    // Start is called before the first frame update
    void Start()
    {
        gameDefinitions = FindObjectOfType<GameDefinitions>();

        if( gameDefinitions.JUNTO)
        {
            
            text.SetText("Uau, vocês Arrasaram!!!\r\nParabéns!!\r\n\r\nJá podem retirar\r\nos equipamentos!");
        }
        else
        {
            text.SetText("Parabéns, você concluiu!!!\r\n\r\n\r\nAguarde o seu colega terminar\r\n para retirar\r\no equipamento...");
        }
    }


}
