using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SequenciaAtiva : MonoBehaviour
{
    public List<int> sequencia = new List<int>();
    [SerializeField] private int proximo;
    public GameObject tubo;
    public Material mat;
    private int pos = 0;

    public int getProximo()
    {
        return proximo;
    }
    public void updateProximo()
    {
        if (pos < sequencia.Count)
        {
            proximo = sequencia.ElementAt(pos);
            pos++;

        }
        else
        {
            tubo.GetComponent<Renderer>().material = mat;

        }
    }

}
