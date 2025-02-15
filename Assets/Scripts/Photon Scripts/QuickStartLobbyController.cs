
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.InputSystem.Controls;
using TMPro;

public class QuickStartLobbyController : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject quickStartButton;
    [SerializeField] private GameObject quickCancelButton;
    [SerializeField] private int roomSize = 2;
    [SerializeField] private int multiplayerSceneIndex;

    GameDefinitions gameDefinitions;

    public GameObject painel;
    public TextMeshProUGUI text;

    private void Start()
    {
        gameDefinitions = GameObject.FindObjectOfType<GameDefinitions>();
    }


    //Callback function for when first connection is estabilish
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        quickStartButton.SetActive(true);
    }

    public void QuickStart() //Paired to the Quick Start Button
    {
                
        if(text.text != "0")
        {            
            quickStartButton.SetActive(false);
            quickCancelButton.SetActive(true);
            CreateRoom();            
            Debug.Log("Quick Start");
        }
        else
        {
            painel.SetActive(true);
        }

    }


    public override void OnJoinedRoom()
    {
        string name = PhotonNetwork.CurrentRoom.Name;
        //int n = int.Parse(name.Substring(name.Length - 1, 1));
        Debug.Log("Joined Room " + name);

        
        if(PhotonNetwork.CurrentRoom != null)
        {
            StartGame();
        }        
    }
     


    public override void OnJoinRoomFailed(short returnCode, string message) //
    {
        Debug.Log("Failed to join the especifed Room");
        CreateRoom();
    }

   

    void CreateRoom() //Trying to create our own Room
    {
        Debug.Log("Creating Room");
        //int RandomRoomNumber = Random.Range(0, 2);
        RoomOptions roomOptions = new RoomOptions() { IsVisible= false, IsOpen=true, MaxPlayers = (byte)roomSize, CleanupCacheOnLeave = false };
        PhotonNetwork.JoinOrCreateRoom("Lab", roomOptions, TypedLobby.Default); //attempting to create a new Room
        Debug.Log("Joined or Created Room");       
        
    }


    public void QuickCancel() //Paired to cancel button
    {
        quickCancelButton.SetActive(false);
        quickStartButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }

    public void StartGame()
    {
       
        if (PhotonNetwork.IsMasterClient)
        {
            
            {
                Debug.Log("Starting Game");
                PhotonNetwork.LoadLevel(multiplayerSceneIndex);

            }
         
        }
    }

   

}
