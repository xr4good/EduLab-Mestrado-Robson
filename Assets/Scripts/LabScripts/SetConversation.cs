using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetConversation : MonoBehaviour
{
    [SerializeField] GameObject painelPai;

    [SerializeField] List<GameObject> dicas;
    [SerializeField] GameObject pedido;
    public List<GameObject> TextosAtivos;

    int countDicas;


    public void FazerPedido()
    {
        IncluirTexto(dicas[countDicas]);

    }
     void IncluirTexto(GameObject novo)
    {
        if (TextosAtivos.Count < 4)
        {
            //instancia o pedido de dica
            GameObject Umpedido = Instantiate(pedido, painelPai.transform);
            TextosAtivos.Add(Umpedido);


            //instancia uma nova dica
            StartCoroutine(InstanciarDica(novo));
        }
        else
        {
            //apaga o primeiro objeto da lista
            GameObject first = TextosAtivos[0];
            first.SetActive(false);
            TextosAtivos.RemoveAt(0);

            //instancia o pedido de dica
            GameObject Umpedido = Instantiate(pedido, painelPai.transform);            
            TextosAtivos.Add(Umpedido);


            //instancia uma nova dica
            GameObject second = TextosAtivos[0];
            second.SetActive(false);
            TextosAtivos.RemoveAt(0);
            StartCoroutine(InstanciarDica(novo));

            
        }
    }

    IEnumerator InstanciarDica(GameObject novo)
    {
        
        yield return new WaitForSeconds(3);
                

        GameObject Umadica = Instantiate(novo, painelPai.transform);
        TextosAtivos.Add(Umadica);
        countDicas++;
        if(countDicas == dicas.Count)
        {
            countDicas = 0;
        }
       


    }
}
