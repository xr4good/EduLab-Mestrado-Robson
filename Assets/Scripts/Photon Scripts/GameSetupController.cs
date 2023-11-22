using UnityEngine;
using Photon.Pun;
using System.IO;
using System.Collections.Generic;

public class GameSetupController : MonoBehaviour
{

    [SerializeField]    private Vector3 pos1; //posicao player 1 na LoadScene 1
    [SerializeField]    private Vector3 pos2; //posicao player 2 na Load Scene 2
    [SerializeField]    private Vector3 pos3; // posicao tutor
    
    
    public GameObject XRPrefab;
    public GameObject ActiveVR;
    private GameObject Mirror;
    public string player;
    [SerializeField] List<GameObject> teleportAreas;
    
    [SerializeField] StartSphere startSphere1;
    [SerializeField] StartSphere startSphere2;

    private int gameTipe;
    private int n;

    // Start is called before the first frame update
    void Start()
    {
        n = PhotonNetwork.CountOfPlayers;
        CreatePlayer(); //Create a networked player Object for each player that loads into the multiplayer
        AtivateTeleportationArea(); //ativa as áreas de teleporte
        CriarEsferas(n); //cria as esferas e a bancada de acordo                
    }


    private void CreatePlayer()
    {
        
        UnityEngine.Debug.Log("Creating Player "+ n);


        //Instanciate XROrigin            
        ActiveVR = Instantiate(XRPrefab, pos(n), Quaternion.identity);
        ActiveVR.GetComponent<ActiveAvatar>().player = "Player"+n;
        player = "Player"+n;

        //ativa o áudio
        Transform cameraOffSet = ActiveVR.transform.Find("CameraOffset");
        Transform mainCamera = cameraOffSet.transform.Find("Main Camera");
        mainCamera.GetComponent<AudioListener>().enabled = true;

        //Instanciate VR Rig Mirror
        Mirror = PhotonNetwork.Instantiate(Path.Combine("XR", "VRRigMirror"+n), pos(n), Quaternion.identity);
        VRMirror vRMirror = Mirror.GetComponent<VRMirror>();
        vRMirror.cameraTransform.originTransform = mainCamera.transform;
        vRMirror.leftHandTransform.originTransform = cameraOffSet.transform.Find("LeftHand").transform;
        vRMirror.rightHandTransform.originTransform = cameraOffSet.transform.Find("RightHand").transform;

   
    }

    private void AtivateTeleportationArea()
    {

        foreach(GameObject obj in teleportAreas)
        {
            obj.SetActive(true);
        }

    }

    private void CriarEsferas(int n)
    {
        if (n == 1)
        {
            startSphere1.CreateSpheres();
            if (!SetGameConfig.JUNTO)
            {
                startSphere2.CreateSpheres();
            }
        }
        
    }

    private Vector3 pos(int n)
    {
        switch (n)
        {
            case 1: return pos1;
            case 2: return pos2;
            case 3: return pos3;
        }
        return pos1;
    }

}
