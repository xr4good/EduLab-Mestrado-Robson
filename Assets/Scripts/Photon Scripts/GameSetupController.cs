using UnityEngine;
using Photon.Pun;
using System.IO;
using System.Collections.Generic;
using UnityEditor.XR.LegacyInputHelpers;
using System.Collections;

public class GameSetupController : MonoBehaviourPunCallbacks
{

    [SerializeField]    private Vector3 pos1; //posicao player 1 na LoadScene 1
    [SerializeField]    private Vector3 pos2; //posicao player 2 na Load Scene 2
    [SerializeField]    private Vector3 pos3; // posicao tutor humanoide
        
    public GameObject XRPrefab;
    public GameObject ActiveVR;
    private GameObject Mirror;
    public string player;
    [SerializeField] List<GameObject> teleportAreas;
    
    [SerializeField] StartSphere startSphere1;
    [SerializeField] StartSphere startSphere2;

    private int n;



    // Start is called before the first frame update
    
    void Start()
    {
        CreatePlayer(); //Create a networked player Object for each player that loads into the multiplayer
        
        AtivateTeleportationArea(); //ativa as áreas de teleporte
        StartCoroutine( CriarEsferas() ); //cria as esferas e a bancada de acordo
    }

    IEnumerator CreateVrMirror (Transform cameraOffSet,Transform mainCamera)
    {
        yield return new WaitForSeconds(2);
        if (GameObject.FindGameObjectsWithTag("Player1").Length == 0)
        {
            n = 1;
        }
        else if (GameObject.FindGameObjectsWithTag("Player2").Length == 0)
        {
            n = 2;
        }
        else
        {
            n = 3;
        }

        UnityEngine.Debug.Log("Creating Online Player " + n);
        ActiveVR.GetComponent<ActiveAvatar>().player = "Player" + n;
        player = "Player" + n;

        //Instanciate VR Rig Mirror
        Mirror = PhotonNetwork.Instantiate(Path.Combine("XR", "VRRigMirror" + n), pos(n), Quaternion.identity);
        VRMirror vRMirror = Mirror.GetComponent<VRMirror>();

        
        vRMirror.cameraTransform.originTransform = mainCamera.transform;
        vRMirror.leftHandTransform.originTransform = cameraOffSet.transform.Find("LeftHand").transform;
        vRMirror.rightHandTransform.originTransform = cameraOffSet.transform.Find("RightHand").transform;
    }

    private void CreatePlayer()
    {

        //Instanciate XROrigin            
        ActiveVR = Instantiate(XRPrefab, pos(n), Quaternion.identity);


        //ativa o áudio
        Transform cameraOffSet = ActiveVR.transform.Find("CameraOffset");
        Transform mainCamera = cameraOffSet.transform.Find("Main Camera");
        mainCamera.GetComponent<AudioListener>().enabled = true;

        //Aguarda 2 segundos e cria VRRig Mirror
        StartCoroutine(CreateVrMirror(cameraOffSet ,mainCamera));
    }

    private void AtivateTeleportationArea()
    {

        foreach(GameObject obj in teleportAreas)
        {
            obj.SetActive(true);
        }

    }

    IEnumerator CriarEsferas()
    {
        yield return new WaitForSeconds(2);
        
        if (GameObject.FindGameObjectsWithTag("Sphere").Length == 0){
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
