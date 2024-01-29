using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOwnerShip : MonoBehaviourPunCallbacks
{
    public void Takeover()
    {
        if (!photonView.IsMine)
        {
            photonView.RequestOwnership();
            Debug.Log("Photon View is mine");
        }
    }
}
