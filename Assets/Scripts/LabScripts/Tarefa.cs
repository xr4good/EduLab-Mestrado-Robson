using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tarefa : MonoBehaviour
{
    public SequenciaAtiva tubo1;
    public SequenciaAtiva tubo2;

    public GameObject fogos;   
    public GameObject limpar;    

    [SerializeField] private List<int> sequencia1 = new List<int>() { 1, 1, 2, 2 };
    [SerializeField] private List<int> sequencia2 = new List<int>() { 2, 2, 1, 1 };
    [SerializeField] private List<int> sequencia3 = new List<int>() { 3, 3, 4, 4 };
    [SerializeField] private List<int> sequencia4 = new List<int>() { 4, 4, 3, 3 };

    [SerializeField] private List<int> sequencia5 = new List<int>() { 4, 2, 4, 2 };
    [SerializeField] private List<int> sequencia6 = new List<int>() { 3, 1, 3, 1 };
    [SerializeField] private List<int> sequencia7 = new List<int>() { 3, 4, 3, 4 };
    [SerializeField] private List<int> sequencia8 = new List<int>() { 1, 2, 1, 2 };

    private int contConcluidos = 0;

    public GameObject painelMeioExperimento;
    public GameObject painelFinalExperimento;



    private void Start()
    {
        tubo1.sequencia.Clear();
        tubo2.sequencia.Clear();

        if (SetGameConfig.SEQUENCIA1)
        {
            tubo1.sequencia = sequencia1;
            tubo2.sequencia = sequencia2;
            
        }
        else
        {
            tubo1.sequencia = sequencia5;
            tubo2.sequencia = sequencia6;
        }

        tubo1.updateProximo();
        tubo2.updateProximo();

    }

   
    void Update()
    {
       if (tubo1.concluido & tubo2.concluido) 
        {
                   
            if (contConcluidos == 1 )  //se tiver concluído a segunda sequencia ativa os fogos e abre a msg
            {
                chamarPaineldeFim();
            }
            else                       //se não abre o painel do meio
            {
                chamarPaineldeMeio();
            }       
            
        }
    }

    void chamarPaineldeMeio()
    {
        painelMeioExperimento.SetActive(true);
        tubo1.concluido = false;
        tubo2.concluido = false;
        contConcluidos++;
    }

    void chamarPaineldeFim()
    {
        fogos.SetActive(true);
        painelFinalExperimento.SetActive(true);
    }
    

    
    public void TrocarSequencia()
    { 
        limpar.SetActive(true);                //ativa animação de limpar
        StartCoroutine(AguardarParaFechar());  //Desativa depois de 2s
                
        tubo1.resertarTubo();      //reseta cor e tira as bolinhas do tubo
        tubo2.resertarTubo();

        tubo1.sequencia.Clear();
        tubo2.sequencia.Clear();

        if (SetGameConfig.SEQUENCIA1)   //coloca a segunda sequencia
        {
            tubo1.sequencia = sequencia3;
            tubo2.sequencia = sequencia4;
        }
        else
        {
            tubo1.sequencia = sequencia7;
            tubo2.sequencia = sequencia8;
        }

        tubo1.updateProximo();
        tubo2.updateProximo();


    }

    IEnumerator AguardarParaFechar()
    {
        yield return new WaitForSeconds(2);
        limpar.SetActive(false);
    }
}
