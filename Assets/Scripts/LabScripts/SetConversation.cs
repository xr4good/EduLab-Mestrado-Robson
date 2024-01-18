using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetConversation : MonoBehaviour
{
    [SerializeField] GameObject painelPai;
    public StatementSender statementSender;
   
    [SerializeField] GameObject pedido;
    public List<GameObject> TextosAtivos;
    public string numeroBancada;

    int countDicas;
    bool isWaiting = false;


    public void FazerPedido()
    {
        if (!isWaiting)
        {
            IncluirTexto();            
            statementSender.logQuestionAnswers("Interacted with Tutor","Corpóreo",true);
        }        

    }
     void IncluirTexto()
    {
        if (TextosAtivos.Count < 4)
        {
            //instancia o pedido de dica
            GameObject Umpedido = PhotonNetwork.Instantiate("MyTexts/Pedido", painelPai.transform.position, painelPai.transform.rotation);
            TextosAtivos.Add(Umpedido);


            //instancia uma nova dica
            StartCoroutine(InstanciarDica());
        }
        else
        {
            //apaga o primeiro objeto da lista
            GameObject first = TextosAtivos[0];
            first.SetActive(false);
            TextosAtivos.RemoveAt(0);

            //instancia o pedido de dica
            GameObject Umpedido = PhotonNetwork.Instantiate("MyTexts/Pedido", painelPai.transform.position, painelPai.transform.rotation);
            TextosAtivos.Add(Umpedido);


            //instancia uma nova dica
            GameObject second = TextosAtivos[0];
            second.SetActive(false);
            TextosAtivos.RemoveAt(0);
            isWaiting = true;
            StartCoroutine(InstanciarDica());

            
        }
    }

    IEnumerator InstanciarDica()
    {
        
        yield return new WaitForSeconds(3);

        GameObject Umadica = PhotonNetwork.Instantiate("MyTexts/Seq" + numeroBancada + "/Dica" + countDicas, painelPai.transform.position, painelPai.transform.rotation);
        TextosAtivos.Add(Umadica);
        countDicas++;
        if(countDicas == 8)
        {
            countDicas = 0;
        }
        isWaiting = false;
       


    }
}
