using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeRotation : MonoBehaviour
{
  
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.rotation = Quaternion.identity;
    }
}
