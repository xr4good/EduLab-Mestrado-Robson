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

        float b = sliderPlayer.value;

        if (b == 1 || b == 2 || b == 5 || b == 6 || b == 9 || b == 10 || b == 13 || b == 14)
        {
            gameDefinitions.ROOM = 1;
        }
        if (b == 17 || b == 18 || b == 21 || b == 22 || b == 25 || b == 26 || b == 29 || b == 30)
        {
            gameDefinitions.ROOM = 2;
        }
        else if (b == 33 || b == 34 || b == 37 || b == 38 || b == 41 || b == 42 || b == 45 || b == 46)
        {
            gameDefinitions.ROOM = 3;
        }
        else if (b == 49 || b == 50 || b == 53 || b == 54 || b == 57 || b == 58 || b == 61 || b == 62)
        {
            gameDefinitions.ROOM = 4;
        }
        else if (b == 3 || b == 4 || b == 19 || b == 20 || b == 35 || b == 36 || b == 51 || b == 52)
        {
            gameDefinitions.ROOM = 5;
        }
        else if (b == 7 || b == 8 || b == 23 || b == 24 || b == 39 || b == 40 || b == 55 || b == 56)
        {
            gameDefinitions.ROOM = 6;
        }
        else if (b == 11 || b == 12 || b == 27 || b == 28 || b == 43 || b == 44 || b == 59 || b == 60)
        {
            gameDefinitions.ROOM = 7;
        }
        else
        {
            gameDefinitions.ROOM = 8;
        }




        //gameDefinitions.ROOM = sliderRoom.value;
        setgameconfig(gameDefinitions.ROOM);
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
            case 5:
                {

                    gameDefinitions.CORPO = true;
                    gameDefinitions.SEQUENCIA1 = true;
                    gameDefinitions.JUNTO = false;
                    break;
                }
            case 2:
                {

                    gameDefinitions.CORPO = false;
                    gameDefinitions.SEQUENCIA1 = true;
                    gameDefinitions.JUNTO = true;
                    break;
                }
            case 6:
                {

                    gameDefinitions.CORPO = false;
                    gameDefinitions.SEQUENCIA1 = true;
                    gameDefinitions.JUNTO = false;
                    break;
                }
            case 3:
                {

                    gameDefinitions.CORPO = true;
                    gameDefinitions.SEQUENCIA1 = false;
                    gameDefinitions.JUNTO = true;
                    break;
                }
            case 7:
                {

                    gameDefinitions.CORPO = true;
                    gameDefinitions.SEQUENCIA1 = false;
                    gameDefinitions.JUNTO = false;
                    break;
                }
            case 4:
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
