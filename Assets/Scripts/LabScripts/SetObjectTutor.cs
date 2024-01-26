using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class SetObjectTutor : MonoBehaviourPunCallbacks
{

    public GameObject Bancada1Transform;
    public GameObject Bancada2Transform;
    private GameObject Help1;
    private GameObject Help2;
    private GameObject laptop1;
    private GameObject laptop2;

    public List<GameObject> Interações;
    public GameObject Sair;

   
    

    // Start is called before the first frame update
    void Awake()
    {
        CarregarObjetosSala();
        CarregarObjetosLab();
    }

    public void InstanciaSaída()
    {
        PhotonNetwork.InstantiateRoomObject(Path.Combine("Objects", Sair.name), Sair.transform.position, Sair.transform.rotation);
    }
    void CarregarObjetosSala()
    {
        foreach(GameObject obj in Interações)
        {
            PhotonNetwork.InstantiateRoomObject(Path.Combine("Objects", obj.name), obj.transform.position, obj.transform.rotation);
        }
        
    }

    void CarregarObjetosLab()
    {
        
         PhotonNetwork.InstantiateRoomObject(Path.Combine("Objects", "Bancada 1"), Bancada1Transform.transform.position, Bancada1Transform.transform.rotation);
        if (!SetGameConfig.JUNTO)
        {
            PhotonNetwork.InstantiateRoomObject(Path.Combine("Objects", "Bancada 2"), Bancada2Transform.transform.position, Bancada2Transform.transform.rotation);
        }


        if (SetGameConfig.CORPO) //se o tutor for corpóreo
        {

            if (SetGameConfig.PERTO)
            {
                PhotonNetwork.InstantiateRoomObject(Path.Combine("Objects", "Help"), Help1.transform.position, Help1.transform.rotation);
               
                if (!SetGameConfig.JUNTO)
                {
                    PhotonNetwork.InstantiateRoomObject(Path.Combine("Objects", "Help"), Help2.transform.position, Help2.transform.rotation);
                }

            }


        }
        else  // se o tutor for objeto
        {
            if (SetGameConfig.PERTO)   // se o tutor estiver perto
            {
                PhotonNetwork.InstantiateRoomObject(Path.Combine("Objects", "laptop"), laptop1.transform.position, laptop1.transform.rotation);

                if (!SetGameConfig.JUNTO)       //se estiver trabalhando em dupla
                {
                    PhotonNetwork.InstantiateRoomObject(Path.Combine("Objects", "laptop"), laptop2.transform.position, laptop2.transform.rotation); ;
                }
            }

        
    }
}
}
    
        
    



