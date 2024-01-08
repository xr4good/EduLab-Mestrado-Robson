using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class SetHeight : MonoBehaviour
{

       
    public GameObject cameraTransform;
    public GameObject cameraOffset;
    


    
    public void corrigirProporcao()
    {
        Vector3 scale = transform.localScale;
        float value = 1 + (cameraOffset.transform.position.y / cameraTransform.transform.position.y);
        scale.x = value;
        scale.y = value;
        scale.z = value;        

    }

}
