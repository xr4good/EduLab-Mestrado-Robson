using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    private bool start = false;
    private double contador = 0;
    public StatementSender statementSender;

    public void StartCounter()
    {
        start = true;
    }
       

    public void StopCounter()
    {
        start=false;
        statementSender.SendStament("Duração da tarefa", contador.ToString(), true, true);
    }

    private void Update()
    {
        if (start)
        {
            contador += Time.deltaTime;
        }
    }


}
