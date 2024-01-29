using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDefinitions : MonoBehaviour
{
    public  bool CORPO = false;           // true corpo, false obj
    public  bool JUNTO = false;           // true player2 junto, false player 2 separado
    public  bool SEQUENCIA1 = false;       //true seq1, false seq 2

    public  string PLAYER;
    public  float ROOM;
    
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    
}
