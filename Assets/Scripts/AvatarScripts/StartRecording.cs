using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRecording : MonoBehaviour
{
    public GameObject player;
    public SavePath savePath;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x == transform.position.x)
        {
            savePath.recording = true;
        }
    }
}
