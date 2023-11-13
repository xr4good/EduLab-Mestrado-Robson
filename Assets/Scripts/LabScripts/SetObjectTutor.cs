using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObjectTutor : MonoBehaviour
{

    public GameObject LaptopBancada1;
    public GameObject LaptopBancada2;
    public GameObject LaptopCentro;

    // Start is called before the first frame update
    void Start()
    {
        if (!SetGameConfig.CORPO)
        {
            if (SetGameConfig.PERTO)
            {
                LaptopBancada1.SetActive(true);
                if (!SetGameConfig.JUNTO)
                {
                    LaptopBancada2.SetActive(true);
                }

            }
            else
            {
                LaptopCentro.SetActive(true);
            }
            
        }
    }

}
