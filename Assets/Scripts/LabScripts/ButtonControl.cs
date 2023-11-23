using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;
    public Slider slider;


    public DefinirSequencia definir;
    public InstanciaBola start;
    int sequenciaAtiva;

    public void OnProximoClicked()
    {
        if (panel1.activeSelf)
        {
            panel1 .SetActive(false);
            panel2 .SetActive(true);
           
        }else {
            panel2 .SetActive(false);
            panel3 .SetActive(true);       
        }
    }

    public void OnVoltarClicked()
    {
        if (panel2.activeSelf)
        {
            panel1.SetActive(true);
            panel2.SetActive(false);
           
        }
        else
        {
            panel2.SetActive(true);
            panel3.SetActive(false);
       
        }
    }

    public void OnIniciarClicked() 
    {
        panel3 .SetActive(false);
        panel4 .SetActive(true);

        sequenciaAtiva = (int)slider.GetComponent<Slider>().value;
        IniciarJogo(sequenciaAtiva);
    }

    public void IniciarJogo(int n)    {
        Debug.Log(n);
        definir.SetSequencias(n);        
        start.StartGame();
    }

    public void OnMudarSequencia()
    {

    }
}
