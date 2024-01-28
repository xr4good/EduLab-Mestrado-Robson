
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

    public GameObject painel;
    public Slider slider;

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
        Debug.Log("Player " + SetGameConfig.PLAYER + " Corpo " + SetGameConfig.CORPO);

        if (PhotonNetwork.IsMasterClient)
        {
            if (SetGameConfig.PLAYER == "65" && SetGameConfig.CORPO)
            {
                Debug.Log("Starting tutor game");
                PhotonNetwork.LoadLevel(multiplayerSceneIndex);
            }
            else if (SetGameConfig.PLAYER != "65")
            {
                Debug.Log("Starting Game");
                PhotonNetwork.LoadLevel(multiplayerSceneIndex);

            }
            else
            {
                Debug.Log("Not bodied tutor allowed");
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
                    SetGameConfig.PERTO = true;
                    SetGameConfig.CORPO = true;
                    SetGameConfig.SEQUENCIA1 = true;
                    SetGameConfig.JUNTO = true;
                    break;
                }
            case 5:
                {
                    SetGameConfig.PERTO = true;
                    SetGameConfig.CORPO = true;
                    SetGameConfig.SEQUENCIA1 = true;
                    SetGameConfig.JUNTO = false;
                    break;
                }
            case 2:
                {
                    SetGameConfig.PERTO = true;
                    SetGameConfig.CORPO = false;
                    SetGameConfig.SEQUENCIA1 = true;
                    SetGameConfig.JUNTO = true;
                    break;
                }
            case6:
                {
                    SetGameConfig.PERTO = true;
                    SetGameConfig.CORPO = false;
                    SetGameConfig.SEQUENCIA1 = true;
                    SetGameConfig.JUNTO = false;
                    break;
                }
            case 3:
                {
                    SetGameConfig.PERTO = true;
                    SetGameConfig.CORPO = true;
                    SetGameConfig.SEQUENCIA1 = false;
                    SetGameConfig.JUNTO = true;
                    break;
                }
            case 7:
                {
                    SetGameConfig.PERTO = true;
                    SetGameConfig.CORPO = true;
                    SetGameConfig.SEQUENCIA1 = false;
                    SetGameConfig.JUNTO = false;
                    break;
                }
            case 4:
                {
                    SetGameConfig.PERTO = true;
                    SetGameConfig.CORPO = false;
                    SetGameConfig.SEQUENCIA1 = false;
                    SetGameConfig.JUNTO = true;
                    break;
                }
            case 8:
                {
                    SetGameConfig.PERTO = true;
                    SetGameConfig.CORPO = false;
                    SetGameConfig.SEQUENCIA1 = false;
                    SetGameConfig.JUNTO = false;
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

}
