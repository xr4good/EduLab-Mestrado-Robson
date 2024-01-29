using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallTutorAnimator : MonoBehaviour
{
    private SetTutorTalk setTutorTalk;

    void Start()
    {
        setTutorTalk = GameObject.FindObjectOfType<SetTutorTalk>();
    }

    public void animarFala()
    {
        setTutorTalk.ResponderDica();
    }
}
