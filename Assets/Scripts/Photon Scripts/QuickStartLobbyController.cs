
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.InputSystem.Controls;

public class QuickStartLobbyController : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject quickStartButton;
    [SerializeField] private GameObject quickCancelButton;
    [SerializeField] private int roomSize;
    [SerializeField] private int multiplayerSceneIndex;

    GameDefinitions gameDefinitions;

    public GameObject painel;
    public Slider slider;

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
                
        if(slider.value != 0)
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
        int n = int.Parse(name.Substring(name.Length - 1, 1));
        Debug.Log("Joined Room " + name);

        setgameconfig(n);
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
        RoomOptions roomOptions = new RoomOptions() { IsVisible= false, IsOpen=true, MaxPlayers = (byte)roomSize};
        PhotonNetwork.JoinOrCreateRoom("Lab" + slider.value, roomOptions, TypedLobby.Default); //attempting to create a new Room
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

    private void setgameconfig(int n)
    {
        Debug.Log("SetGameConfig " + n);

        switch (n)
        {
            case 1:
                {
                    
                    gameDefinitions.CORPO = true;
                    gameDefinitions.SEQUENCIA1 = true;
                    gameDefinitions.JUNTO = true;
                    break;
                }
            case 2:
                {

                    gameDefinitions.CORPO = true;
                    gameDefinitions.SEQUENCIA1 = true;
                    gameDefinitions.JUNTO = false;
                    break;
                }
            case 3:
                {

                    gameDefinitions.CORPO = false;
                    gameDefinitions.SEQUENCIA1 = true;
                    gameDefinitions.JUNTO = true;
                    break;
                }
            case 4:
                {

                    gameDefinitions.CORPO = false;
                    gameDefinitions.SEQUENCIA1 = true;
                    gameDefinitions.JUNTO = false;
                    break;
                }
            case 5:
                {

                    gameDefinitions.CORPO = true;
                    gameDefinitions.SEQUENCIA1 = false;
                    gameDefinitions.JUNTO = true;
                    break;
                }
            case 6:
                {

                    gameDefinitions.CORPO = true;
                    gameDefinitions.SEQUENCIA1 = false;
                    gameDefinitions.JUNTO = false;
                    break;
                }
            case 7:
                {

                    gameDefinitions.CORPO = false;
                    gameDefinitions.SEQUENCIA1 = false;
                    gameDefinitions.JUNTO = true;
                    break;
                }
            case 8:
                {

                    gameDefinitions.CORPO = false;
                    gameDefinitions.SEQUENCIA1 = false;
                    gameDefinitions.JUNTO = false;
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

}
