using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarFall : MonoBehaviour
{   
  
    MoveToLab move;
    // Start is called before the first frame update
    private void Start()
    {
        move = FindObjectOfType<MoveToLab>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 12.26 ||
            transform.position.x < -1.49 ||
            transform.position.z > 4.2 ||
            transform.position.z < -3.3 )
        {            
            move.LoadScene();
        } 
        
    }
}
                                   