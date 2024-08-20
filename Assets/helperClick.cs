using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helperClick : MonoBehaviour
{
    // Start is called before the first frame update

    //public GameObject helperLeft;
    public GameObject helperRight;

    bool isActive = false;

    public void switchActive()

    {
        if(isActive)
        {
           // helperLeft.SetActive(false);
            helperRight.SetActive(false);
            isActive = false;
        }
        else
        {
           // helperLeft.SetActive(true);
            helperRight.SetActive(true);
            isActive = true;
        }
        
    }

    
}
