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
        setgameconfig(sliderRoom.value);
    }

    private void setgameconfig(float n)
    {
        Debug.Log("SetGameConfig " + n);

        switch (n)
        {
            case 1:
                {

                    gameDefinitions.CORPO = true;
                    gameDefinitions.SEQUENCIA1 = true;
                    gameDefinitions.JUNTO = true;
                    break;
                }
            case 2:
                {

                    gameDefinitions.CORPO = true;
                    gameDefinitions.SEQUENCIA1 = true;
                    gameDefinitions.JUNTO = false;
                    break;
                }
            case 3:
                {

                    gameDefinitions.CORPO = false;
                    gameDefinitions.SEQUENCIA1 = true;
                    gameDefinitions.JUNTO = true;
                    break;
                }
            case 4:
                {

                    gameDefinitions.CORPO = false;
                    gameDefinitions.SEQUENCIA1 = true;
                    gameDefinitions.JUNTO = false;
                    break;
                }
            case 5:
                {

                    gameDefinitions.CORPO = true;
                    gameDefinitions.SEQUENCIA1 = false;
                    gameDefinitions.JUNTO = true;
                    break;
                }
            case 6:
                {

                    gameDefinitions.CORPO = true;
                    gameDefinitions.SEQUENCIA1 = false;
                    gameDefinitions.JUNTO = false;
                    break;
                }
            case 7:
                {

                    gameDefinitions.CORPO = false;
                    gameDefinitions.SEQUENCIA1 = false;
                    gameDefinitions.JUNTO = true;
                    break;
                }
            case 8:
                {

                    gameDefinitions.CORPO = false;
                    gameDefinitions.SEQUENCIA1 = false;
                    gameDefinitions.JUNTO = false;
                    break;
                }
            default:
                {
                    break;
                }
        }
    }
}
