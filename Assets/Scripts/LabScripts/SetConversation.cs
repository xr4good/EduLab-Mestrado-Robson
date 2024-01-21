using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SetConversation : MonoBehaviour
{
    [SerializeField] GameObject painelPai;

    [SerializeField] List<GameObject> dicas1;
    [SerializeField] List<GameObject> dicas2;
    [SerializeField] GameObject pedido;
    public List<GameObject> TextosAtivos;

    int countDicas;
    int totalDicas;
    bool isWaiting = false;

    public StatementSender statementSender;


    public void FazerPedido()
    {
        if (!isWaiting)
        {
            if (SetGameConfig.SEQUENCIA1)
            {
                IncluirTexto(dicas1[countDicas]);
                totalDicas = dicas1.Count;
                statementSender.SendStament("Solicitou Dica / Objeto", "Sequencia1", true, false);
            }
            else
            {
                IncluirTexto(dicas2[countDicas]);
                totalDicas = dicas2.Count;
                statementSender.SendStament("Solicitou Dica / Objeto", "Sequencia2", true, false);
            }            
            
        }        
        

    }
    void IncluirTexto(GameObject novo)
    {
        if (TextosAtivos.Count < 4)
        {
            //instancia o pedido de dica
            GameObject Umpedido = Instantiate(pedido, painelPai.transform);
            TextosAtivos.Add(Umpedido);


            //instancia uma nova dica
            isWaiting = true;
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
            isWaiting=true;
            StartCoroutine(InstanciarDica(novo));


        }
    }

    IEnumerator InstanciarDica(GameObject novo)
    {

        yield return new WaitForSeconds(3);


        GameObject Umadica = Instantiate(novo, painelPai.transform);
        TextosAtivos.Add(Umadica);
        countDicas++;
        if (countDicas == totalDicas)
        {
            countDicas = 0;
        }
        isWaiting = false;

    }
}