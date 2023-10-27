
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class QuickStartLobbyController : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject quickStartButton;
    [SerializeField] private GameObject quickCancelButton;
    [SerializeField] private int roomSize;
    public Slider slider;
    public GameObject painel;

    public Toggle check;
    public Toggle distancia;
    public Toggle posicaoInicial;
    public Toggle sequencia;
    public Toggle corpo;

    //Callback function for when first connection is estabilish
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        quickStartButton.SetActive(true);
    }

    public void QuickStart() //Paired to the Quick Start Button
    {
        
        if(check.isOn)
        {
            SetGameConfig.DISTANCIA = distancia.isOn;
            SetGameConfig.CORPO = corpo.isOn;
            SetGameConfig.SEQUENCIA = sequencia.isOn;
            SetGameConfig.POSICAOINICAL = posicaoInicial.isOn;

            quickStartButton.SetActive(false);
            quickCancelButton.SetActive(true);
            PhotonNetwork.JoinRoom("Lab"); //First tries to join an existing room
            Debug.Log("Quick Start");
        }
        else
        {
            painel.SetActive(true);
        }
        
    }

    public override void OnJoinRoomFailed(short returnCode, string message) //
    {
        Debug.Log("Failed to join the Room");
        CreateRoom();
    }

    void CreateRoom() //Trying to create our own Room
    {
        Debug.Log("Creating Room");
        //int RandomRoomNumber = Random.Range(0, 2);
        RoomOptions roomOptions = new RoomOptions() { IsVisible= true, IsOpen=true, MaxPlayers = (byte)roomSize};
        PhotonNetwork.CreateRoom("Lab", roomOptions); //attempting to create a new Room
        Debug.Log("RoomCreated");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to create room... trying again");
        CreateRoom();
    }

    public void QuickCancel() //Paired to cancel button
    {
        quickCancelButton.SetActive(false);
        quickStartButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }
}
