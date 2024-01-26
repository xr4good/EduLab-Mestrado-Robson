using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ChangePainel : MonoBehaviour
{
    public List<GameObject> paineis;
    public int pos = 0;

    public GameObject botaoProximo;
    public GameObject botaoAnterior;
    SetObjectTutor setObject;

    private void Awake()
    {
        setObject = GameObject.FindObjectOfType<SetObjectTutor>();
    }

    public void Proximo()
    {
        paineis[pos].SetActive(false);
        pos++;
        paineis[pos].SetActive(true);

        if (pos == paineis.Count - 1)
        {
            botaoProximo.SetActive(false);
            botaoAnterior.SetActive(true);
            setObject.InstanciaSaída();
        }
        else
        {
            botaoProximo.SetActive(true);
            botaoAnterior.SetActive(true);
        }                

    }
 
    public void Anterior()
    {
        
           paineis[pos].SetActive(false);
           pos--;
           paineis[pos].SetActive(true);
                      

        if (pos == 0)
        {
            botaoAnterior.SetActive(false);
            botaoProximo.SetActive(true);
        }
        else
        {
            botaoProximo.SetActive(true);
            botaoAnterior.SetActive(true);
        }
    }    

}
