using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurnOffFreezeGrab : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Locomotion.Movement.GrabMoveProvider grabMoveProvider;

    // Start is called before the first frame update
    void Start()
    {
        grabMoveProvider.enableFreeXMovement = false;
        grabMoveProvider.enableFreeYMovement = false;
        grabMoveProvider.enableFreeZMovement = false;
    }

}
