using UnityEngine;
using Photon.Pun;
using System.IO;
using UnityEngine.XR.Interaction.Toolkit;
using NUnit.Framework;
using System.Collections.Generic;

public class GameSetupController : MonoBehaviour
{

    [SerializeField]    private Vector3 pos1;
    [SerializeField]    private Vector3 pos2;
    [SerializeField]    private Vector3 pos3;
    public GameObject XRPrefab;
    public GameObject ActiveVR;
    private GameObject Mirror;
    public string player;
    [SerializeField] List<GameObject> teleportAreas;
    [SerializeField] List<StartSphere> startSpheres;
        


    // Start is called before the first frame update
    void Start()
    {
        CreatePlayer(); //Create a networked player Object for each player that loads into the multiplayer
        AtivateTeleportationArea();
        
    }


    private void CreatePlayer()
    {
        
        if(PhotonNetwork.CountOfPlayers == 1)
        {
              
            UnityEngine.Debug.Log("Creating Player 1");


            //Instanciate XROrigin            
            ActiveVR = Instantiate(XRPrefab, pos1, Quaternion.identity);
            ActiveVR.GetComponent<ActiveAvatar>().player = "Player1";
            player = "Player1";

            //ativa o áudio
            Transform cameraOffSet = ActiveVR.transform.Find("CameraOffset");
            Transform mainCamera = cameraOffSet.transform.Find("Main Camera");
            mainCamera.GetComponent<AudioListener>().enabled = true;

            //Instanciate VR Rig Mirror
            Mirror = PhotonNetwork.Instantiate(Path.Combine("XR", "VRRigMirror1"), pos1, Quaternion.identity);
            VRMirror vRMirror = Mirror.GetComponent<VRMirror>();
            vRMirror.cameraTransform.originTransform = mainCamera.transform;
            vRMirror.leftHandTransform.originTransform = cameraOffSet.transform.Find("LeftHand").transform;
            vRMirror.rightHandTransform.originTransform = cameraOffSet.transform.Find("RightHand").transform;

            foreach(StartSphere startSphere in startSpheres)
            {
                startSphere.CreateSpheres();
            }

        }
        else if(PhotonNetwork.CountOfPlayers == 2)
        {

            UnityEngine.Debug.Log("Creating Player 2");

            //Instanciate XROrigin            
            ActiveVR = Instantiate(XRPrefab, pos2, Quaternion.identity);
            ActiveVR.GetComponent<ActiveAvatar>().player = "Player2";
            player = "Player2";

            //ativa o áudio
            Transform cameraOffSet = ActiveVR.transform.Find("CameraOffset");
            Transform mainCamera = cameraOffSet.transform.Find("Main Camera");
            mainCamera.GetComponent<AudioListener>().enabled = true;

            //Instanciate VR Rig Mirror
            Mirror = PhotonNetwork.Instantiate(Path.Combine("XR", "VRRigMirror2"), pos2, Quaternion.identity);
            VRMirror vRMirror = Mirror.GetComponent<VRMirror>();
            vRMirror.cameraTransform.originTransform = mainCamera.transform;
            vRMirror.leftHandTransform.originTransform = cameraOffSet.transform.Find("LeftHand").transform;
            vRMirror.rightHandTransform.originTransform = cameraOffSet.transform.Find("RightHand").transform;


        }
        else 
        {
            UnityEngine.Debug.Log("Creating Player 3");

            /*
            //Instanciate XROrigin            
            ActiveVR = Instantiate(XRPrefab, pos3, Quaternion.identity);
            ActiveVR.GetComponent<ActiveAvatar>().player = "Player3";
            player = "Player3";

            //ativa o áudio
            Transform cameraOffSet = ActiveVR.transform.Find("CameraOffset");
            Transform mainCamera = cameraOffSet.transform.Find("Main Camera");
            mainCamera.GetComponent<AudioListener>().enabled = true;

            //Instanciate VR Rig Mirror
            Mirror = PhotonNetwork.Instantiate(Path.Combine("XR", "VRRigMirror3"), pos3, Quaternion.identity);
            VRMirror vRMirror = Mirror.GetComponent<VRMirror>();
            vRMirror.cameraTransform.originTransform = mainCamera.transform;
            vRMirror.leftHandTransform.originTransform = cameraOffSet.transform.Find("LeftHand").transform;
            vRMirror.rightHandTransform.originTransform = cameraOffSet.transform.Find("RightHand").transform;
            */

        }

    }

    private void AtivateTeleportationArea()
    {

        foreach(GameObject obj in teleportAreas)
        {
            obj.SetActive(true);
        }

    }

}
