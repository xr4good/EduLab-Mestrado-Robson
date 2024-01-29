using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTutorTalk : MonoBehaviourPunCallbacks
{

    [SerializeField] private TutorAnimatorController animator;
    
    public void ResponderDica()
    {
        Dica();
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

    }

}
