using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UIElements;
using System.IO;
using UnityEditor.XR.LegacyInputHelpers;
using ReadyPlayerMe.Core.WebView;

public class LoadAvatar : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    [SerializeField] private int numeroAvatar;
    [SerializeField] private GameSetupController setup;   
    private GameObject XR;
    private GameObject avatar;    
    //public VRTargetsPosition positions;
    //public int nplayer;


    IEnumerator trocarAvatar()
    {
        yield return new WaitForSeconds(2);

        XR = GameObject.FindGameObjectWithTag("Player");

        XR = setup.ActiveVR;

        //instancia o avatar e recupera o seu controler
        if (XR.GetComponent<ActiveAvatar>().avatar != null)
        {
            PhotonNetwork.Destroy(XR.GetComponent<ActiveAvatar>().avatar);
        }



        if (setup.player == "Player1")
        {
            avatar = PhotonNetwork.Instantiate(Path.Combine("MyAvatars1", "Avatar" + numeroAvatar), XR.transform.position, Quaternion.identity);
        }
        else if (setup.player == "Player2")
        {
            avatar = PhotonNetwork.Instantiate(Path.Combine("MyAvatars2", "Avatar" + numeroAvatar), XR.transform.position, Quaternion.identity);
        }
        else
        {

        }

        AvatarController control = avatar.GetComponent<AvatarController>();


        //troca o layer dos componentes que serão invisíveis para a camera
        NotSeeHead notSeeHead = avatar.GetComponent<NotSeeHead>();
        //notSeeHead.IgnoreLayer = XR.GetComponent<ActiveAvatar>().player;
        notSeeHead.changeLayer();

        //Trocando o que a câmera pode ver       
        Transform cameraOffSet = XR.transform.Find("CameraOffset");
        Transform mainCamera = cameraOffSet.transform.Find("Main Camera");
        Camera camera = mainCamera.GetComponent<Camera>();
        camera.cullingMask &= ~(1 << LayerMask.NameToLayer(notSeeHead.IgnoreLayer));
        camera.cullingMask &= ~(1 << LayerMask.NameToLayer("DICA"));

        //troca a proporção do avatar de acordo com a altura do usuario
        //float value = 1 * (cameraOffSet.transform.position.y / mainCamera.transform.position.y);        
        //avatar.transform.localScale = new Vector3(value, value, value);        


        /*Setup the VR Target in the Avatar        
        control.head.vrTarget = cameraOffSet.Find("Main Camera").transform;
        control.leftHand.vrTarget = cameraOffSet.Find("LeftHand").transform;
        control.rightHand.vrTarget = cameraOffSet.Find("RightHand").transform;*/

        //Informa qual o avatar ativo para o XR
        XR.GetComponent<ActiveAvatar>().avatar = avatar;
        avatar.GetComponent<AnimateOnInput>().ativeAvatar = XR.GetComponent<ActiveAvatar>();
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
    }

    public void AvatarChange()
    {
        StartCoroutine(trocarAvatar());

    }

}

