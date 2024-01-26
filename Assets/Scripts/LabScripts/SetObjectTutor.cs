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
    public List<GameObject> Interações;
    public GameObject Sair;

    private GameObject Bancada1;
    private GameObject Bancada2;

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
        
        Bancada1 = PhotonNetwork.InstantiateRoomObject(Path.Combine("Objects", "Bancada 1"), Bancada1Transform.transform.position, Bancada1Transform.transform.rotation);
        if (!SetGameConfig.JUNTO)
        {
            Bancada2 = PhotonNetwork.InstantiateRoomObject(Path.Combine("Objects", "Bancada 2"), Bancada2Transform.transform.position, Bancada2Transform.transform.rotation);
            //Bancada2.SetActive(true);
        }


        if (SetGameConfig.CORPO) //se o tutor for corpóreo
        {

            if (SetGameConfig.PERTO)
            {
                GameObject Help1 = Bancada1.transform.Find("Help").gameObject;
                Help1.SetActive(true);

                if (!SetGameConfig.JUNTO)
                {
                    GameObject Help2 = Bancada2.transform.Find("Help").gameObject;
                    Help2.SetActive(true);
                }

            }


        }
        else  // se o tutor for objeto
        {
            if (SetGameConfig.PERTO)   // se o tutor estiver perto
            {
                GameObject LaptopBancada1 = Bancada1.transform.Find("laptop").gameObject;
                LaptopBancada1.SetActive(true);

                if (!SetGameConfig.JUNTO)       //se estiver trabalhando em dupla
                {
                    GameObject LaptopBancada2 = Bancada2.transform.Find("laptop").gameObject;
                    LaptopBancada2.SetActive(true);
                }
            }

        
    }
}
}
    
        
    



