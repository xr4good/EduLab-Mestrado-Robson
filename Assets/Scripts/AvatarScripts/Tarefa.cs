using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tarefa : MonoBehaviour
{
    public int experimento = 0;

    public SequenciaAtiva tubo1;
    public SequenciaAtiva tubo2;

    public Animation fogos;

    [SerializeField] private List<int> sequencia1 = new List<int>() { 1, 1, 2, 2 };
    [SerializeField] private List<int> sequencia2 = new List<int>() { 2, 2, 1, 1 };
    [SerializeField] private List<int> sequencia3 = new List<int>() { 3, 3, 4, 4 };
    [SerializeField] private List<int> sequencia4 = new List<int>() { 4, 4, 3, 3 };

    [SerializeField] private List<int> sequencia5 = new List<int>() { 4, 2, 4, 2 };
    [SerializeField] private List<int> sequencia6 = new List<int>() { 3, 1, 3, 1 };
    [SerializeField] private List<int> sequencia7 = new List<int>() { 4, 3, 4, 3 };
    [SerializeField] private List<int> sequencia8 = new List<int>() { 3, 4, 3, 4 };


    private void Start()
    {
           
    }

   
    void Update()
    {
       if (tubo1.concluido & tubo2.concluido) 
        {
        
        }
    }
}
