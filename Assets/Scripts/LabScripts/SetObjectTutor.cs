using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SetObjectTutor : MonoBehaviourPunCallbacks
{

    public GameObject LaptopBancada1;
    public GameObject LaptopBancada2;
    public GameObject LaptopLonge;
    public GameObject Help1;
    public GameObject Help2;
    public GameObject HelpLonge;
    public GameObject ButtonTutor;
    public GameObject dicas1;
    public GameObject dicas2;

    public GameObject Bancada2;

    // Start is called before the first frame update
    void Start()
    {
        if(PhotonNetwork.CountOfPlayers == 1)
        {

            if (!SetGameConfig.JUNTO)
            {
                Bancada2.SetActive(true);
            }

            
            if (SetGameConfig.CORPO) //se o tutor for corpóreo
            {
                if(SetGameConfig.PLAYER == "65")
                {
                    ButtonTutor.SetActive(true);

                        if (SetGameConfig.SEQUENCIA1)
                        {
                            dicas1.SetActive(true);

                        }
                        else
                        {
                            dicas2.SetActive(true);
                        }
                    
                }
                if (SetGameConfig.PERTO)
                {
                    Help1.SetActive(true);

                    if (!SetGameConfig.JUNTO)
                    {
                        Help2.SetActive(true);                        
                    }

                }
                else
                {
                    HelpLonge.SetActive(true);
                }

            }
            else  // se o tutor for objeto
            {
                if (SetGameConfig.PERTO)   // se o tutor estiver perto
                {
                    LaptopBancada1.SetActive(true);

                    if (!SetGameConfig.JUNTO)       //se estiver trabalhando em dupla
                    {                     
                        LaptopBancada2.SetActive(true);                       
                    }
                }
                else  //se o tutor estiver longe
                {
                    LaptopLonge.SetActive(true);
                }

            }
        }
    }
    
        
    


}
