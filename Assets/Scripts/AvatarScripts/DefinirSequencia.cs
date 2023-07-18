using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefinirSequencia : MonoBehaviour
{
    public SequenciaAtiva tubo1;
    public SequenciaAtiva tubo2;
    public SequenciaAtiva tubo3;
    public SequenciaAtiva tubo4;
    [SerializeField] private int sequencia;

    
    public void SetSequencias(int n)
    {
        Debug.Log(n);
        sequencia = n;
        switch (n)
        {
            case 0:                
                tubo1.sequencia = new List<int>() { 0,1,0,1 }; tubo1.updateProximo();
                tubo2.sequencia = new List<int>() { 1,0,1,0 }; tubo2.updateProximo();
                tubo3.sequencia = new List<int>() { 4,5,4,5 }; tubo3.updateProximo();
                tubo4.sequencia = new List<int>() { 5,4,5,4 }; tubo4.updateProximo();
                break;
           case 1:
                tubo1.sequencia = new List<int>() { 0,1,2,3 }; tubo1.updateProximo();
                tubo2.sequencia = new List<int>() { 1,2,3,0 }; tubo2.updateProximo();
                tubo3.sequencia = new List<int>() { 2,3,0,1 }; tubo3.updateProximo();
                tubo4.sequencia = new List<int>() { 3,0,1,2 }; tubo4.updateProximo();
                break;
           case 2:
                tubo1.sequencia = new List<int>() { 3,3,3,3 }; tubo1.updateProximo();
                tubo2.sequencia = new List<int>() { 6,6,6,6 }; tubo2.updateProximo();
                tubo3.sequencia = new List<int>() { 2,2,2,2 }; tubo3.updateProximo();
                tubo4.sequencia = new List<int>() { 5,5,5,5 }; tubo4.updateProximo();
                break;

        }
    }
}
