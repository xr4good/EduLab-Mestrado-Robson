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
            
            text.SetText("Uau, voc�s Arrasaram!!!\r\nParab�ns!!\r\n\r\nJ� podem retirar\r\nos equipamentos!");
        }
        else
        {
            text.SetText("Parab�ns, voc� concluiu!!!\r\n\r\n\r\nAguarde o seu colega terminar\r\n para retirar\r\no equipamento...");
        }
    }


}
