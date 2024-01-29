using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallTutorAnimator : MonoBehaviour
{
    private SetTutorTalk setTutorTalk;
    private AudioDicas audio;

    void Start()
    {
        setTutorTalk = GameObject.FindObjectOfType<SetTutorTalk>();
        audio = GameObject.FindObjectOfType<AudioDicas>();
    }

    public void animarFala()
    {
        setTutorTalk.ResponderDica();
        audio.FalarDica();
    }
}
