using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tarefa : MonoBehaviour
{
    public SequenciaAtiva tubo1;
    public SequenciaAtiva tubo2;

    public GameObject fogos;
    public ParticleSystem fogosArtificio;

    [SerializeField] private List<int> sequencia1 = new List<int>() { 1, 1, 2, 2 };
    [SerializeField] private List<int> sequencia2 = new List<int>() { 2, 2, 1, 1 };
    [SerializeField] private List<int> sequencia3 = new List<int>() { 3, 3, 4, 4 };
    [SerializeField] private List<int> sequencia4 = new List<int>() { 4, 4, 3, 3 };

    [SerializeField] private List<int> sequencia5 = new List<int>() { 4, 2, 4, 2 };
    [SerializeField] private List<int> sequencia6 = new List<int>() { 3, 1, 3, 1 };
    [SerializeField] private List<int> sequencia7 = new List<int>() { 4, 3, 4, 3 };
    [SerializeField] private List<int> sequencia8 = new List<int>() { 3, 4, 3, 4 };

    private int contConcluidos = 0;

    public GameObject painelMeioExperimento;
    public GameObject painelFinalExperimento;

    private void Start()
    {
        if (SetGameConfig.PRIMEIROEXPERIMENTO)
        {
            if (SetGameConfig.SEQUENCIA)
            {
                tubo1.sequencia = sequencia1;
                tubo2.sequencia = sequencia1;
            }
            else
            {
                tubo1.sequencia = sequencia5;
                tubo2.sequencia = sequencia5;
            }
        }
        else
        {
            if (SetGameConfig.SEQUENCIA)
            {
                tubo1.sequencia = sequencia3;
                tubo2.sequencia = sequencia3;
            }
            else
            {
                tubo1.sequencia = sequencia7;
                tubo2.sequencia = sequencia7;
            }
        }
        
    }

   
    void Update()
    {
       if (tubo1.concluido & tubo2.concluido) 
        {
            contConcluidos++;            //conta quantas sequencias foram concluídas

            

            if (contConcluidos == 2)
            {
                fogos.SetActive(true);
                fogosArtificio.Play();
                EncerrarExperimento();
            }
            else
            {
                TrocarSequencia();
            }       

            
        }
    }

    void EncerrarExperimento()
    {
        if (SetGameConfig.PRIMEIROEXPERIMENTO)
        {
            painelMeioExperimento.SetActive(true);
            TrocarSequencia();
        }
        else
        {
            painelFinalExperimento.SetActive(true);
        }
    }

    void TrocarSequencia()
    {
        tubo1.concluido = false;
        tubo2.concluido = false;
        if(SetGameConfig.PRIMEIROEXPERIMENTO)
        {
            if (SetGameConfig.SEQUENCIA)
            {
                tubo1.sequencia = sequencia2;
                tubo2.sequencia = sequencia2;
            }
            else
            {
                tubo1.sequencia = sequencia6;
                tubo2.sequencia = sequencia6;
            }
        }
        else
        {
            if (SetGameConfig.SEQUENCIA)
            {
                tubo1.sequencia = sequencia4;
                tubo2.sequencia = sequencia4;
            }
            else
            {
                tubo1.sequencia = sequencia8;
                tubo2.sequencia = sequencia8;
            }
        }
        
    }
}
