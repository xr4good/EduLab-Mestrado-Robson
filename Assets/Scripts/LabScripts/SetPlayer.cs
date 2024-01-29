using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPlayer : MonoBehaviour
{
    public Slider sliderPlayer;
    public Slider sliderRoom;
    GameDefinitions gameDefinitions;
    private void Start()
    {
        gameDefinitions = FindObjectOfType<GameDefinitions>();
    }

    public void ChangePlayer()
    {
        gameDefinitions.PLAYER = sliderPlayer.value.ToString();
    }

    public void ChangeRoom()
    {
        gameDefinitions.ROOM = sliderRoom.value;
    }
}
