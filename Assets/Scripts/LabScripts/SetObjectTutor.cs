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
    public Vector3 pos;
  

    public List<GameObject> Interações;
    public GameObject Sair;

    GameDefinitions gameDefinitions;


    // Start is called before the first frame update
    void Start()
    {
        gameDefinitions = FindObjectOfType<GameDefinitions>();
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
         
        if (gameDefinitions.CORPO) //se o tutor for corpóreo
        {

            PhotonNetwork.InstantiateRoomObject(Path.Combine("XR", "Tutor"), pos, Quaternion.identity);

            PhotonNetwork.InstantiateRoomObject(Path.Combine("Objects", "Bancada 1 Help"), Bancada1Transform.transform.position, Bancada1Transform.transform.rotation);
               
                if (!gameDefinitions.JUNTO)
                {
                    PhotonNetwork.InstantiateRoomObject(Path.Combine("Objects", "Bancada 2 Help"), Bancada2Transform.transform.position, Bancada2Transform.transform.rotation);
                }

           


        }
        else  // se o tutor for objeto
        {
                PhotonNetwork.InstantiateRoomObject(Path.Combine("Objects", "Bancada 1 laptop"), Bancada1Transform.transform.position, Bancada1Transform.transform.rotation);

                if (!gameDefinitions.JUNTO)
                {
                    PhotonNetwork.InstantiateRoomObject(Path.Combine("Objects", "Bancada 2 laptop"), Bancada2Transform.transform.position, Bancada2Transform.transform.rotation);
                }       

        }

    }

}
    
        
    



