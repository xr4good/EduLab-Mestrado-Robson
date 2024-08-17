using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    private float contador = 0;
    public StatementSender statementSender;
    GameDefinitions gameDefinitions;

    public void StartCounter()
    {
        StartCoroutine(updatecontagem());
    }
       
   

    IEnumerator updatecontagem()
    {
        yield return new WaitForSeconds(30);
        contador += 0.5f;
        using (StreamWriter sw = new StreamWriter(Application.dataPath + "/Logs/TimePlayer" + gameDefinitions.PLAYER + ".csv", true))
        {
            sw.WriteLine(contador);
        }
        StartCoroutine(updatecontagem());
    }

    private void Start()
    {
        gameDefinitions = FindObjectOfType<GameDefinitions>();
    }

}
