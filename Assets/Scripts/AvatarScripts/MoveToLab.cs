
using Photon.Pun;
using System.Collections;
using UnityEngine;

public class MoveToLab : MonoBehaviourPunCallbacks
{
    [SerializeField] Vector3 posicao1;
    [SerializeField] Vector3 posicao2junto;
    [SerializeField] Vector3 posicao2separado;

    
    [SerializeField]private bool first = true;

    

    [PunRPC]
    void ChangeFirst(bool isFirst)
    {
        first = isFirst;
    }


    public void LoadScene()
    {
        
        StartCoroutine(aoPressionar());
    }

    IEnumerator aoPressionar()
    {
        yield return new WaitForSeconds(2);
        GameObject XR = GameObject.FindGameObjectWithTag("Player");
        ActiveAvatar activeAvatar = XR.GetComponent<ActiveAvatar>();
        GameObject Mirror = GameObject.FindGameObjectWithTag(activeAvatar.player);
        
        if ( first)
        {           
            XR.transform.position = posicao1;
            Mirror.transform.position= posicao1;
            this.photonView.RPC("ChangeFirst", RpcTarget.All, false);
            TimeCounter time = GameObject.FindObjectOfType<TimeCounter>();
            time.StartCounter();
        }
        else
        {            
            if (SetGameConfig.JUNTO)
            {
                XR.transform.position = posicao2junto;
                Mirror.transform.position = posicao2junto;
            }
            else
            {
                XR.transform.position = posicao2separado;
                Mirror.transform.position = posicao2separado;
            }
            
        }       
    }

}
