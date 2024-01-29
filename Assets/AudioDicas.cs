using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDicas : MonoBehaviourPunCallbacks
{
    public List<AudioClip> dicas1;
    public List<AudioClip> dicas2;
    [SerializeField] private AudioSource audioSource;
    int numeroDica = 0;
    public float volume = 0.8f;

    public void FalarDica()
    {
        this.photonView.RPC("SoltarDica", RpcTarget.All);
    }

    [PunRPC]
    IEnumerator SoltarDica()
    {
        yield return new WaitForSeconds(3);

        if (SetGameConfig.SEQUENCIA1)
        {
            AudioSource.PlayClipAtPoint(dicas1[numeroDica], audioSource.transform.position);
            //audioSource.PlayOneShot(dicas1[numeroDica], volume);
            numeroDica++;
            if (numeroDica == dicas1.Count)
            {
                numeroDica = 0;
            }
        }
        else
        {
            AudioSource.PlayClipAtPoint(dicas2[numeroDica], audioSource.transform.position);
            //audioSource.PlayOneShot(dicas2[numeroDica], volume);
            numeroDica++;
            if (numeroDica == dicas2.Count)
            {
                numeroDica = 0;
            }
        }
    }
}
