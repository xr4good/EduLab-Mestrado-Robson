using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObjectTutor : MonoBehaviour
{

    public GameObject LaptopBancada1;
    public GameObject LaptopBancada2;
    public GameObject LaptopCentro;

    public GameObject Bancada2;

    // Start is called before the first frame update
    void Start()
    {
        if (!SetGameConfig.JUNTO)
        {
            Bancada2.SetActive(true);
        }

        //se estiver junto só bancada 1 se não 1 e 2 ativas

        if (!SetGameConfig.CORPO)  // se o tutor for objeto
        {
            if (SetGameConfig.PERTO)   // se o tutor estiver perto
            {
                LaptopBancada1.SetActive(true);
                if (SetGameConfig.JUNTO)       //se estiver trabalhando em dupla
                {
                    
                    LaptopBancada1.SetActive(true);
                }
                else                         //se estiverem trabalhando individualmente
                {
                    LaptopBancada1.SetActive(true);
                    LaptopBancada2.SetActive(true);
                }

            }
            else  //se o tutor estiver longe
            {
                LaptopCentro.SetActive(true);
            }
            
        }
    }

}
