
using Photon.Pun;
using System.Collections;
using UnityEngine;

public class MoveToLab : MonoBehaviourPunCallbacks
{
    [SerializeField] Vector3 posicao1;
    [SerializeField] Vector3 posicao2junto;
    [SerializeField] Vector3 posicao2separado;

    
    [SerializeField]private bool first = true;

    LoadAvatar loadAvatar;
    GameDefinitions gameDefinitions;

    private void Start()
    {
        loadAvatar = GameObject.FindObjectOfType<LoadAvatar>();
        gameDefinitions = FindObjectOfType<GameDefinitions>();
    }
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
        int n = XR.GetComponent<ActiveAvatar>().numeroAvatar;
              
        
        
        if ( first)
        {           
            XR.transform.position = posicao1;
            loadAvatar.ChangeAvatar(n);
          
            this.photonView.RPC("ChangeFirst", RpcTarget.All, false);
            TimeCounter time = GameObject.FindObjectOfType<TimeCounter>();
            time.StartCounter();
        }
        else
        {            
            if (gameDefinitions.JUNTO)
            {
                XR.transform.position = posicao2junto;
                loadAvatar.ChangeAvatar(n);
            }
            else
            {
                XR.transform.position = posicao2separado;
                loadAvatar.ChangeAvatar(n);
            }
            
        }       
    }

}
