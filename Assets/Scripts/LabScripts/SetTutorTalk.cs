using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTutorTalk : MonoBehaviourPunCallbacks
{

    [SerializeField] private TutorAnimatorController animator;

    private Transform initpos;
    private bool isReponding = false;

    StatementSender statementSender;
    GameDefinitions gameDefinitions;
  

    public void ResponderDica()
    {
                
        if (!isReponding)
        {
            Dica();
            isReponding = true;
            if (gameDefinitions.SEQUENCIA1)
            {
                statementSender.SendStament("Solicitou Dica / Humano", "Sequencia1", true, false);
            }
            else
            {
                statementSender.SendStament("Solicitou Dica / Humano", "Sequencia2", true, false);
            }
        }
    }

    [PunRPC]
    void Dica()
    {
        StartCoroutine(IniciarAjuda());
    }


    IEnumerator IniciarAjuda()
    {
        yield return new WaitForSeconds(3);
        animator.AnimarFala();
        yield return new WaitForSeconds(2);
        isReponding = false;

    }

    


    private void Start()
    {
        initpos = this.gameObject.transform;
        statementSender = GameObject.FindObjectOfType<StatementSender>();
        gameDefinitions = FindObjectOfType<GameDefinitions>();
    }

    private void Update()
    {
        this.gameObject.transform.rotation = initpos.rotation;
    }

}
