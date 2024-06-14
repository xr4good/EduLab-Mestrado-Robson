using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTutorTalk : MonoBehaviourPunCallbacks
{

    [SerializeField] private TutorAnimatorController animator;
    private Transform initpos;
    
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

    private void Start()
    {
        initpos = this.gameObject.transform;
    }

    private void Update()
    {
        this.gameObject.transform.rotation = initpos.rotation;
    }

}
