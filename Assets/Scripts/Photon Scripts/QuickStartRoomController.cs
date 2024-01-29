using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class QuickStartRoomController : MonoBehaviourPunCallbacks
{
    /*
    [SerializeField] private int multiplayerSceneIndex; //Number for the build index to the multiplay scene
    public bool joined = false;
    [SerializeField] private GameObject ButtonEntrar;

    public override void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    override
    public void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    

    public override void OnJoinedRoom()
    {
        
        string name = PhotonNetwork.CurrentRoom.Name;
        int n = int.Parse(name.Substring(name.Length - 1, 1));
        Debug.Log("Joined Room "+ n);

        setgameconfig(n);       
        StartGame();
        joined = true;
        //ButtonEntrar.SetActive(true);

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
            else if(SetGameConfig.PLAYER != "65")
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
                   
                    SetGameConfig.CORPO = true;
                    SetGameConfig.SEQUENCIA1 = true;
                    SetGameConfig.JUNTO = true;
                    break;
                }
            case 2:
                {
                
                    SetGameConfig.CORPO = true;
                    SetGameConfig.SEQUENCIA1 = true;
                    SetGameConfig.JUNTO = false;
                    break;
                }
            case 3:
                {
               
                    SetGameConfig.CORPO = false;
                    SetGameConfig.SEQUENCIA1 = true;
                    SetGameConfig.JUNTO = true;
                    break;
                }
            case 4:
                {
                    
                    SetGameConfig.CORPO = false;
                    SetGameConfig.SEQUENCIA1 = true;
                    SetGameConfig.JUNTO = false;
                    break;
                }
            case 5:
                {
               
                    SetGameConfig.CORPO = true;
                    SetGameConfig.SEQUENCIA1 = false;
                    SetGameConfig.JUNTO = true;
                    break;
                }
            case 6:
                {
              
                    SetGameConfig.CORPO = true;
                    SetGameConfig.SEQUENCIA1 = false;
                    SetGameConfig.JUNTO = false;
                    break;
                }
            case 7:
                {
                   
                    SetGameConfig.CORPO = false;
                    SetGameConfig.SEQUENCIA1 = false;
                    SetGameConfig.JUNTO = true;
                    break;
                }
            case 8:
                {
                 
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
       */
}
