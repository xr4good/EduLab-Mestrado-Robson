using Photon.Pun;
using UnityEngine;



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
        if(originTransform != null)
        {
            mirrorTransform.position = originTransform.position;
            mirrorTransform.rotation = originTransform.rotation;
        }
        
    }

 
}
