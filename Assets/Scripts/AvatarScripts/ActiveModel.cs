using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Android.LowLevel;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ActiveModel : MonoBehaviour
{    
    [SerializeField] List<ActionBasedController> controllers;

    //Remove os modelos de controle para instanciar os Avatares
   public void desativarModel()
    {       
        foreach (var controller in controllers)
        {        
            controller.hideControllerModel = true;
            
        }
    }
}
