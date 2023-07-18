using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class UpStairs : MonoBehaviour
{
    public GameObject playerGO;
    //if the player touches the stairs goes to the top
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerGO.transform.position = new Vector3(-4, 21.5f, 42);
        }
    }


    

}
