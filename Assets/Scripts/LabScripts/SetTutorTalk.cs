using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTutorTalk : MonoBehaviourPunCallbacks
{
    private AcenderLampada lampada;
    [SerializeField] private TutorAnimatorController animator;
    public List<AudioClip> dicas1;
    public List<AudioClip> dicas2;
    [SerializeField] private AudioSource audioSource;
    int numeroDica = 0;

    private void Start()
    {
        lampada = GameObject.FindObjectOfType<AcenderLampada>();
    }

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

        lampada.Apagar();
        animator.AnimarFala();
        if (SetGameConfig.SEQUENCIA1)
        {
            audioSource.clip = dicas1[numeroDica];
            audioSource.Play();
        }
        else
        {
            audioSource.clip = dicas2[numeroDica];
            audioSource.Play();
        }

    }

}
