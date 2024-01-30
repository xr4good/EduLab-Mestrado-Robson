using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarFall : MonoBehaviour
{   
    public float posiCair;
    MoveToLab move;
    // Start is called before the first frame update
    private void Start()
    {
        move = FindObjectOfType<MoveToLab>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < posiCair)
        {            
            move.LoadScene();
        } 
    }
}
