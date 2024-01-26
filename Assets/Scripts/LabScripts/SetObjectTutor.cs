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
    

    public GameObject Bancada2;

    // Start is called before the first frame update
    public void StartConfig()
    {
            if (!SetGameConfig.JUNTO)
            {
                Bancada2.SetActive(true);
            }

            
            if (SetGameConfig.CORPO) //se o tutor for corpóreo
            {
                
                if (SetGameConfig.PERTO)
                {
                    Help1.SetActive(true);

                    if (!SetGameConfig.JUNTO)
                    {
                        Help2.SetActive(true);                        
                    }

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
    
        
    



