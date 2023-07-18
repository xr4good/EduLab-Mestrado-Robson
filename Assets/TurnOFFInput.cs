using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using UnityEngine.Rendering;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class TurnOFFInput : MonoBehaviourPunCallbacks
{
    [SerializeField] SnapTurnProviderBase snapTurnProvider;
    [SerializeField] ActionBasedContinuousMoveProvider actionBasedContinuousMoveProvider;
    [SerializeField] DynamicMoveProvider dynamicMoveProvider;
    [SerializeField] TwoHandedGrabMoveProvider twoHandedGrabMoveProvider;
    //[SerializeField] InputSystem trackedPoseDrive;
    [SerializeField] ActionBasedControllerManager actionBasedControllerManagerLeft;
    [SerializeField] XRController XRControllerLeft;
    [SerializeField] GrabMoveProvider GrabMoveProviderLeft;
    [SerializeField] ActionBasedControllerManager actionBasedControllerManagerRight;
    [SerializeField] XRController XRControllerRight;
    [SerializeField] GrabMoveProvider GrabMoveProviderRight;



    // Start is called before the first frame update
    void Start()
    {
        if (!photonView.IsMine)
        {
            snapTurnProvider.enabled = false;
            actionBasedContinuousMoveProvider.enabled = false;
            dynamicMoveProvider.enabled = false;
            twoHandedGrabMoveProvider.enabled = false;
            //trackedPoseDrive.enabled = false;
            actionBasedControllerManagerLeft.enabled = false;
            XRControllerLeft.enabled = false;
            GrabMoveProviderLeft.enabled = false;
            actionBasedControllerManagerRight.enabled = false;
            XRControllerRight.enabled = false;
            GrabMoveProviderRight.enabled = false;

        }
    }
}
