using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tarefa : MonoBehaviour
{
    public SequenciaAtiva tubo;
    public GameObject painelFinalExperimento;
    public GameObject fogos;   
   

    private List<int> sequencia1 = new List<int>() { 1, 2, 4, 2, 3, 2, 4, 3, 1 };
    private List<int> sequencia2 = new List<int>() { 2, 4, 3, 1, 1, 3, 2, 2, 4 };


    void Awake()
    {
        tubo.sequencia.Clear();
      

        if (SetGameConfig.SEQUENCIA1)
        {
            tubo.sequencia = sequencia1;                  
        }
        else
        {
            tubo.sequencia = sequencia2;     
        }

        tubo.updateProximo();
      

    }

   
    void Update()
    {
       if (tubo.concluido) 
        {            
             chamarPaineldeFim();                      
        }
    }

 
    void chamarPaineldeFim()
    {
        fogos.SetActive(true);
        painelFinalExperimento.SetActive(true);
    }
    


}
