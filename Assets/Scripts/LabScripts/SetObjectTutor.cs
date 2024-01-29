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


    private List<int> sequencia1 = new List<int>() { 1, 2, 4, 2, 3, 2, 4, 3, 1 };
    private List<int> sequencia2 = new List<int>() { 2, 4, 3, 1, 1, 3, 2, 2, 4 };

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
         
        if (SetGameConfig.CORPO) //se o tutor for corpóreo
        {

            PhotonNetwork.InstantiateRoomObject(Path.Combine("XR", "Tutor"), pos, Quaternion.identity);

            PhotonNetwork.InstantiateRoomObject(Path.Combine("Objects", "Bancada 1 Help"), Bancada1Transform.transform.position, Bancada1Transform.transform.rotation);
               
                if (!SetGameConfig.JUNTO)
                {
                    PhotonNetwork.InstantiateRoomObject(Path.Combine("Objects", "Bancada 2 Help"), Bancada2Transform.transform.position, Bancada2Transform.transform.rotation);
                }

           


        }
        else  // se o tutor for objeto
        {
                PhotonNetwork.InstantiateRoomObject(Path.Combine("Objects", "Bancada 1 laptop"), Bancada1Transform.transform.position, Bancada1Transform.transform.rotation);

                if (!SetGameConfig.JUNTO)
                {
                    PhotonNetwork.InstantiateRoomObject(Path.Combine("Objects", "Bancada 2 laptop"), Bancada2Transform.transform.position, Bancada2Transform.transform.rotation);
                }       

        }

        foreach (SequenciaAtiva tubo in GameObject.FindObjectsOfType<SequenciaAtiva>())
        {
            this.photonView.RPC("trocarSequencia", RpcTarget.All, tubo);
        }
         
    }

    [PunRPC]
    void trocarSequencia(SequenciaAtiva tubo)
    {
        tubo.sequencia.Clear();


        if (SetGameConfig.SEQUENCIA1)
        {
            tubo.sequencia = sequencia1;
        }
        else
        {
            tubo.sequencia = sequencia2;
        }

        tubo.updateProximo();

    }
}
    
        
    



