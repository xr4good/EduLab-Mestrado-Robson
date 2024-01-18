using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPlayer : MonoBehaviour
{
    public Slider sliderPlayer;
    public Slider sliderRoom;

    public void ChangePlayer()
    {
        SetGameConfig.PLAYER = sliderPlayer.value.ToString();
    }

    public void ChangeRoom()
    {
        SetGameConfig.ROOM = sliderRoom.value.ToString();
    }
}
