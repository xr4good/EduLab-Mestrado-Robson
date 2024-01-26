using UnityEngine;
using Photon.Pun;
using System.IO;
using System.Collections.Generic;
using UnityEditor.XR.LegacyInputHelpers;
using System.Collections;
using UnityEngine.UI;

public class GameSetupController : MonoBehaviourPunCallbacks
{

    [SerializeField]    private Vector3 pos1; //posicao player 1 na LoadScene 1
    [SerializeField]    private Vector3 pos2; //posicao player 2 na Load Scene 2
    [SerializeField]    private Vector3 pos3; // posicao tutor humanoide
        
    public GameObject XRPrefab;
    public GameObject ActiveVR;
    private GameObject Mirror;

   public string player;  
    
    [SerializeField] StartSphere startSphere1;
    [SerializeField] StartSphere startSphere2;

    private int n;

    public GameObject ButtonTutor;
    public GameObject dicas1;
    public GameObject dicas2;



    // Start is called before the first frame update

    void Awake()
    {
        if(SetGameConfig.PLAYER == "65")
        {
            StartCoroutine(CreateTutor());
        }
        else
        {
            StartCoroutine( CreatePlayer() ); //Create a networked player Object for each player that loads into the multiplayer
        }
        
        
        //AtivateTeleportationArea(); //ativa as áreas de teleporte
        StartCoroutine( CriarEsferas() ); //cria as esferas e a bancada de acordo
        
    }

    
    
    IEnumerator CreatePlayer()
    {
        yield return new WaitForSeconds(1);

        Debug.Log("Player 1 found: " + GameObject.FindGameObjectsWithTag("Player1").Length);
        Debug.Log("Player 2 found: " + GameObject.FindGameObjectsWithTag("Player2").Length);

        if (GameObject.FindGameObjectsWithTag("Player1").Length == 0)
        {
            n = 1;
        }
        else if (GameObject.FindGameObjectsWithTag("Player2").Length == 0)
        {
            n = 2;
        }

        //Instanciate XROrigin            
        ActiveVR = Instantiate(XRPrefab, pos(n), Quaternion.identity);
        

        //ativa o áudio
        Transform cameraOffSet = ActiveVR.transform.Find("CameraOffset");
        Transform mainCamera = cameraOffSet.transform.Find("Main Camera");
        mainCamera.GetComponent<AudioListener>().enabled = true;
        

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

    IEnumerator CreateTutor()
    {
        yield return new WaitForSeconds(1);
        n = 3;

        //Instanciate XROrigin            
        ActiveVR = Instantiate(XRPrefab, pos(n), Quaternion.identity);
       

        //ativa o áudio
        Transform cameraOffSet = ActiveVR.transform.Find("CameraOffset");
        Transform mainCamera = cameraOffSet.transform.Find("Main Camera");
        mainCamera.GetComponent<AudioListener>().enabled = true;
                
        //Aguarda 2 segundos e cria VRRig Mirror
        UnityEngine.Debug.Log("Creating Tutor");
        ActiveVR.GetComponent<ActiveAvatar>().player = "Tutor";
        player = "Tutor";

        //Instanciate VR Rig Mirror
        Mirror = PhotonNetwork.Instantiate(Path.Combine("XR", "VRRigMirror" + n), pos(n), Quaternion.identity);
        VRMirror vRMirror = Mirror.GetComponent<VRMirror>();
        Mirror.tag = "Tutor";


        vRMirror.cameraTransform.originTransform = mainCamera.transform;
        vRMirror.leftHandTransform.originTransform = cameraOffSet.transform.Find("LeftHand").transform;
        vRMirror.rightHandTransform.originTransform = cameraOffSet.transform.Find("RightHand").transform;

        GameObject avatar = PhotonNetwork.Instantiate (Path.Combine("XR", "Tutor"), ActiveVR.transform.position, Quaternion.identity);
                


        //Informa qual o avatar ativo para o XR
        ActiveVR.GetComponent<ActiveAvatar>().avatar = avatar;
        avatar.GetComponent<AnimateOnInput>().ativeAvatar = ActiveVR.GetComponent<ActiveAvatar>();
        avatar.GetComponent<AvatarAnimationController>().enabled = true;

        PhotonAnimatorView photonAnimatorView = avatar.GetComponent<PhotonAnimatorView>();
        photonAnimatorView.SetLayerSynchronized(0, PhotonAnimatorView.SynchronizeType.Discrete);
        photonAnimatorView.SetLayerSynchronized(1, PhotonAnimatorView.SynchronizeType.Discrete);
        photonAnimatorView.SetLayerSynchronized(2, PhotonAnimatorView.SynchronizeType.Discrete);
        photonAnimatorView.SetParameterSynchronized("Left Pinch", PhotonAnimatorView.ParameterType.Float, PhotonAnimatorView.SynchronizeType.Discrete);
        photonAnimatorView.SetParameterSynchronized("Right Pinch", PhotonAnimatorView.ParameterType.Float, PhotonAnimatorView.SynchronizeType.Discrete);
        photonAnimatorView.SetParameterSynchronized("Left Grab", PhotonAnimatorView.ParameterType.Float, PhotonAnimatorView.SynchronizeType.Discrete);
        photonAnimatorView.SetParameterSynchronized("Right Grab", PhotonAnimatorView.ParameterType.Float, PhotonAnimatorView.SynchronizeType.Discrete);
        photonAnimatorView.SetParameterSynchronized("isMoving", PhotonAnimatorView.ParameterType.Bool, PhotonAnimatorView.SynchronizeType.Discrete);
        photonAnimatorView.SetParameterSynchronized("animSpeed", PhotonAnimatorView.ParameterType.Float, PhotonAnimatorView.SynchronizeType.Discrete);


        ButtonTutor.SetActive(true);

        if (SetGameConfig.SEQUENCIA1)
        {
            dicas1.SetActive(true);

        }
        else
        {
            dicas2.SetActive(true);
        }
                
    }

}
