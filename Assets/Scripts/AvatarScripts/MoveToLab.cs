
using Photon.Pun;
using System.Collections;
using UnityEngine;

public class MoveToLab : MonoBehaviourPunCallbacks
{
    [SerializeField] Vector3 posicao1;
    [SerializeField] Vector3 posicao2junto;
    [SerializeField] Vector3 posicao2separado;

    LoadAvatar loadAvatar;
    GameDefinitions gameDefinitions;

    private void Start()
    {
        loadAvatar = GameObject.FindObjectOfType<LoadAvatar>();
        gameDefinitions = FindObjectOfType<GameDefinitions>();
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
              
        
        
        if ( gameDefinitions.PLAYER %2 != 0)
        {           
            XR.transform.position = posicao1;
            loadAvatar.ChangeAvatarTeste(n);
          
            //this.photonView.RPC("ChangeFirst", RpcTarget.All, false);
            TimeCounter time = GameObject.FindObjectOfType<TimeCounter>();
            time.StartCounter();
        }
        else
        {            
            if (gameDefinitions.JUNTO)
            {
                XR.transform.position = posicao2junto;
                loadAvatar.ChangeAvatarTeste(n);
            }
            else
            {
                XR.transform.position = posicao2separado;
                loadAvatar.ChangeAvatarTeste(n);
            }
            
        }       
    }

}
