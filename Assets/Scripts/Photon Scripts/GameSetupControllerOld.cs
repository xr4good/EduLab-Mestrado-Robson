using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using System.Runtime.CompilerServices;


public class GameSetupControllerOld : MonoBehaviour
{

    [SerializeField] private Vector3 pos1;
    [SerializeField] private Vector3 pos2;
    [SerializeField] private Vector3 pos3;

    [SerializeField] private Material cor1;
    [SerializeField] private Material cor2;
    [SerializeField] private Material cor3;

    private AvatarController control;
    private GameObject Robo;
    public GameObject XR;



    // Start is called before the first frame update
    void Start()
    {
        CreatePlayer(); //Create a networked player Object for each player that loads into the multiplayer

    }

    private void CreatePlayer()
    {
        if (PhotonNetwork.CountOfPlayers == 1)
        {

            Debug.Log("Creating Player 1");
            //Instanciate Robot and XROrigin
            Robo = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonPlayer"), pos1, Quaternion.identity);
            XR = Instantiate(XR, pos1, Quaternion.identity);

            //Change Color of Robot
            Robo.GetComponentInChildren<Renderer>().material = cor1;

            //Setup the VR Target in the Robot
            Transform XROrigin = XR.transform.Find("XR Origin");
            Transform cameraOffSet = XROrigin.transform.Find("CameraOffset");

            control = Robo.GetComponent<AvatarController>();
            control.head.vrTarget = cameraOffSet.Find("Main Camera").transform;
            control.leftHand.vrTarget = cameraOffSet.Find("LeftHand").transform;
            control.rightHand.vrTarget = cameraOffSet.Find("RightHand").transform;

            //Change the Layer from Robot and Make it invisible for his own camera
            int layer = LayerMask.NameToLayer("Player1");
            GameObject face = Robo.transform.Find("Robot").gameObject;
            face.layer = layer;

            int oldMask = cameraOffSet.GetComponentInChildren<Camera>().cullingMask;
            cameraOffSet.GetComponentInChildren<Camera>().cullingMask &= ~(1 << LayerMask.NameToLayer("Player1"));

        }
        else if (PhotonNetwork.CountOfPlayers == 2)
        {

            Debug.Log("Creating Player 2");
            //Instanciate Robot and XROrigin
            Robo = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonPlayer"), pos2, Quaternion.identity);
            XR = Instantiate(XR, pos2, Quaternion.identity);

            //Change Color of Robot
            Robo.GetComponentInChildren<Renderer>().material = cor2;

            //Setup the VR Target in the Robot
            Transform XROrigin = XR.transform.Find("XR Origin");
            Transform cameraOffSet = XROrigin.transform.Find("CameraOffset");

            control = Robo.GetComponent<AvatarController>();
            control.head.vrTarget = cameraOffSet.Find("Main Camera").transform;
            control.leftHand.vrTarget = cameraOffSet.Find("LeftHand").transform;
            control.rightHand.vrTarget = cameraOffSet.Find("RightHand").transform;

            //Change the Layer from Robot and Make it invisible for his own camera
            int layer = LayerMask.NameToLayer("Player2");
            GameObject face = Robo.transform.Find("Robot").gameObject;
            face.layer = layer;

            int oldMask = cameraOffSet.GetComponentInChildren<Camera>().cullingMask;
            cameraOffSet.GetComponentInChildren<Camera>().cullingMask &= ~(1 << LayerMask.NameToLayer("Player2"));

        }
        else
        {
            Debug.Log("Creating Player 3");
            //Instanciate Robot and XROrigin
            Robo = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "myRobot"), pos3, Quaternion.identity);
            XR = Instantiate(XR, pos3, Quaternion.identity);

            //Change Color of Robot
            Robo.GetComponentInChildren<Renderer>().material = cor3;

            //Setup the VR Target in the Robot
            Transform XROrigin = XR.transform.Find("XR Origin");
            Transform cameraOffSet = XROrigin.transform.Find("CameraOffset");

            control = Robo.GetComponent<AvatarController>();
            control.head.vrTarget = cameraOffSet.Find("Main Camera").transform;
            control.leftHand.vrTarget = cameraOffSet.Find("LeftHand").transform;
            control.rightHand.vrTarget = cameraOffSet.Find("RightHand").transform;

            //Change the Layer from Robot and Make it invisible for his own camera
            int layer = LayerMask.NameToLayer("Player3");
            GameObject face = Robo.transform.Find("Robot").gameObject;
            face.layer = layer;

            int oldMask = cameraOffSet.GetComponentInChildren<Camera>().cullingMask;
            cameraOffSet.GetComponentInChildren<Camera>().cullingMask &= ~(1 << LayerMask.NameToLayer("Player3"));

        }

    }

}
