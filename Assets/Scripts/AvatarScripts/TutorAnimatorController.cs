using Photon.Pun;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class TutorAnimatorController : MonoBehaviourPunCallbacks
{

    [SerializeField] private Animator animator;

    public void AnimarFala()
    {
        this.photonView.RPC("AnimateTalk", RpcTarget.All);
    }

   
    [PunRPC]
    void AnimateTalk()
    {
        this.animator.SetBool("isTalking", true);
        StartCoroutine(StopAnimation());
    }

    IEnumerator StopAnimation()
    {
        yield return new WaitForSeconds(2);
        this.animator.SetBool("isTalking", false);
       
    }
}

