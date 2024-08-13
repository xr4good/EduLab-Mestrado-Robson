using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallTutorAnimator : MonoBehaviour
{
    private SetTutorTalk setTutorTalk;
    private AudioDicas audioD;

    void Start()
    {
        setTutorTalk = GameObject.FindObjectOfType<SetTutorTalk>();
        audioD = GameObject.FindObjectOfType<AudioDicas>();
    }

    public void animarFala()
    {
        setTutorTalk.ResponderDica();
        audioD.FalarDica();
    }
}
