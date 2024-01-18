using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TutorNetworkController : MonoBehaviourPunCallbacks
{

    public GameObject seq1;
    public GameObject seq2;


    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("We are now connected to the " + PhotonNetwork.AppVersion + " server!");
        PhotonNetwork.AutomaticallySyncScene = true;

        PhotonNetwork.JoinRandomRoom();//First tries to join an existing room                                           
        Debug.Log("Quick Start");
    }

      

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join the random Room");

        WaitRoom();
    }



    public override void OnJoinedRoom()
    {
        string name = PhotonNetwork.CurrentRoom.Name;
        int n = int.Parse(name.Substring(name.Length - 1, 1));
        Debug.Log("Room number " + n);

        if(n < 5)
        {
            seq1.SetActive(true);
        }
        else
        {
            seq2.SetActive(true);
        }
    }

    void WaitRoom() //Trying to create our own Room
    {
        Debug.Log("Waiting Room");
        StartCoroutine(TryToEnter());

    }

    IEnumerator TryToEnter()
    {
        yield return new WaitForSeconds(2);
        PhotonNetwork.JoinRandomRoom();//Tries to join an existing room

    }


}
