using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    private bool start = false;
    private double contador = 0;
    public StatementSender statementSender;
    GameDefinitions gameDefinitions;

    public void StartCounter()
    {
        start = true;
    }
       

    public void StopCounter()
    {
        //start=false;
        //statementSender.SendStament("Duração da tarefa", contador.ToString(), true, true);
    }

    private void Update()
    {
        if (start)
        {
            contador += Time.deltaTime;
            using (StreamWriter sw = new StreamWriter(Application.dataPath + "/Logs/TimePlayer" + gameDefinitions.PLAYER + ".csv", true))
            {
                sw.WriteLine(contador); ;
            }
        }
    }

    private void Start()
    {
        gameDefinitions = FindObjectOfType<GameDefinitions>();
    }

}
