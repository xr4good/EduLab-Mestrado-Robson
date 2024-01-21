using Photon.Pun;
using UnityEngine;


[System.Serializable]
public class MapTransform
{
    public Transform vrTarget;
    public Transform IKTarget;
    public Vector3 trackingPositionOffset;
    public Vector3 trackingRotationOffset;
    public Transform correction;
    

    public void MapVRAvatar()
    {
        
        if(correction!= null) {

            IKTarget.position = vrTarget.TransformPoint(trackingPositionOffset);
            IKTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffset) * correction.rotation;
        }
        else
        {
            IKTarget.position = vrTarget.TransformPoint(trackingPositionOffset );
            IKTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffset);
        }
        
    }


}

public class AvatarController : MonoBehaviourPunCallbacks//, IPunObservable
{
    [SerializeField] public MapTransform head;
    [SerializeField] public MapTransform leftHand;
    [SerializeField] public MapTransform rightHand;

    [SerializeField] private float turnSmoothness;

    [SerializeField] private Transform IKHead;

    [SerializeField] private Vector3 headBodyOffset;
    [SerializeField] private string tag;
    [SerializeField] private float height;

    private GameObject Mirror;

    private void Start()
    {
        GameObject gameSetup = GameObject.Find("GameSetup");
        
        Mirror = GameObject.FindWithTag(tag);
        if(Mirror != null)
        {
            head.vrTarget = Mirror.transform.Find("CameraMirror");
            leftHand.vrTarget = Mirror.transform.Find("LeftHandMirror");
            rightHand.vrTarget = Mirror.transform.Find("RightHandMirror");
        }
        
    }


    private void LateUpdate()
    {
            transform.position = new Vector3(IKHead.position.x, height, IKHead.position.z) + headBodyOffset;
            //transform.position = IKHead.position + headBodyOffset;
            //transform.rotation = IKHead.rotation * Quaternion.Euler(headBodyRotationOffset);
            transform.forward = Vector3.Lerp(transform.forward, Vector3.ProjectOnPlane(IKHead.forward, Vector3.up).normalized, Time.deltaTime * turnSmoothness); ;
            head.MapVRAvatar();
            leftHand.MapVRAvatar();
            rightHand.MapVRAvatar();


    }

}
