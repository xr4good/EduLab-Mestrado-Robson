
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
            PhotonNetwork.JoinRandomRoom();//First tries to join an existing room                                           
            Debug.Log("Quick Start");
        }
        else
        {
            painel.SetActive(true);
        }

    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join the random Room");
        CreateRoom();
    }


    public override void OnJoinRoomFailed(short returnCode, string message) //
    {
        Debug.Log("Failed to join the especifed Room");
        //CreateRoom();
    }

    public override void OnJoinedRoom()
    {
        string name = PhotonNetwork.CurrentRoom.Name;
        int n = int.Parse(name.Substring(name.Length - 1, 1));
        Debug.Log("Room number " + n);

        setgameconfig(n);
    }

    void CreateRoom() //Trying to create our own Room
    {
        Debug.Log("Creating Room");
        //int RandomRoomNumber = Random.Range(0, 2);
        RoomOptions roomOptions = new RoomOptions() { IsVisible= true, IsOpen=true, MaxPlayers = (byte)roomSize};
        if(slider.value != 0 )
        {
            PhotonNetwork.CreateRoom("Lab" + slider.value, roomOptions); //attempting to create a new Room
            Debug.Log("RoomCreated");
        }    
        
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

    private void setgameconfig(int n)
    {
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
            case 2:
                {
                    SetGameConfig.PERTO = true;
                    SetGameConfig.CORPO = true;
                    SetGameConfig.SEQUENCIA1 = true;
                    SetGameConfig.JUNTO = false;
                    break;
                }
            case 3:
                {
                    SetGameConfig.PERTO = true;
                    SetGameConfig.CORPO = false;
                    SetGameConfig.SEQUENCIA1 = true;
                    SetGameConfig.JUNTO = true;
                    break;
                }
            case 4:
                {
                    SetGameConfig.PERTO = true;
                    SetGameConfig.CORPO = false;
                    SetGameConfig.SEQUENCIA1 = true;
                    SetGameConfig.JUNTO = false;
                    break;
                }
            case 5:
                {
                    SetGameConfig.PERTO = true;
                    SetGameConfig.CORPO = true;
                    SetGameConfig.SEQUENCIA1 = false;
                    SetGameConfig.JUNTO = true;
                    break;
                }
            case 6:
                {
                    SetGameConfig.PERTO = true;
                    SetGameConfig.CORPO = true;
                    SetGameConfig.SEQUENCIA1 = false;
                    SetGameConfig.JUNTO = false;
                    break;
                }
            case 7:
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
