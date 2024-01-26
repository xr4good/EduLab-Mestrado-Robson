using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TurnOffFreezeGrab : MonoBehaviour
{
    public GrabMoveProvider grabMoveProvider;

    // Start is called before the first frame update
    void Start()
    {
        grabMoveProvider.enableFreeXMovement = false;
        grabMoveProvider.enableFreeYMovement = false;
        grabMoveProvider.enableFreeZMovement = false;
    }

}
