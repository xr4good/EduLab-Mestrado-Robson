using System.Collections;
using UnityEngine;
using Photon.Pun;
using System.IO;


public class LoadAvatar : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    
    [SerializeField] private GameSetupController setup;   
    private GameObject XR;
    private GameObject avatar;
    //public VRTargetsPosition positions;
    //public int nplayer;
    StatementSender statementSender;
     


    IEnumerator trocarAvatar(int numeroAvatar, float height )
    {
        yield return new WaitForSeconds(2);
       
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
        
        //avatar.GetComponent<AvatarController>().height = height;
        AvatarController control = avatar.GetComponent<AvatarController>();


        //troca o layer dos componentes que serão invisíveis para a camera
        NotSeeHead notSeeHead = avatar.GetComponent<NotSeeHead>();
        //notSeeHead.IgnoreLayer = XR.GetComponent<ActiveAvatar>().player;
        notSeeHead.changeLayer();

        //Trocando o que a câmera pode ver       
        Transform mainCamera = XR.transform.Find("Camera Offset").transform.Find("Main Camera");      
        Camera camera = mainCamera.GetComponent<Camera>();
        camera.cullingMask &= ~(1 << LayerMask.NameToLayer(notSeeHead.IgnoreLayer));
        camera.cullingMask &= ~(1 << LayerMask.NameToLayer("DICA"));

      
        //Informa qual o avatar ativo para o XR
        XR.GetComponent<ActiveAvatar>().avatar = avatar;
        XR.GetComponent<ActiveAvatar>().numeroAvatar = numeroAvatar;
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
        

        //remove o controle do avatar
        XR.GetComponent<ActiveModel>().desativarModel();
    }

    public void ChangeAvatar(int numeroAvatar)
    {
        StartCoroutine(trocarAvatar(numeroAvatar, -9.45f));
        statementSender.SendStament("Escolheu avatar", numeroAvatar.ToString(), false, false); 


    }

    public void ChangeAvatarTeste(int numeroAvatar)
    {
        StartCoroutine(trocarAvatar(numeroAvatar, -6.265f));
    }

    private void Start()
    {
        statementSender = FindObjectOfType<StatementSender>();
    }

}

