using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class VRMirror : MonoBehaviourPunCallbacks
{
    public MapTransformMirror cameraTransform;
    public MapTransformMirror leftHandTransform;
    public MapTransformMirror rightHandTransform;


    // Update is called once per frame
    void LateUpdate()
    {
        if (photonView.IsMine)
        {
            cameraTransform.MirrorTransform();
            leftHandTransform.MirrorTransform();
            rightHandTransform.MirrorTransform();
           
        }        
        

    }
}

[System.Serializable]
public class MapTransformMirror 
{
    public Transform originTransform;
    public Transform mirrorTransform;

    public void MirrorTransform()
    {        
        mirrorTransform.position = originTransform.position;
        mirrorTransform.rotation = originTransform.rotation;
    }

 
}
