using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCorreto : MonoBehaviour
{
    
    public GameObject bolaPrefab;   
    private GameObject bola;
    [SerializeField] private Vector3 posicaoInicial;
    public SequenciaAtiva sequencia;

    private void Start()
    {
        sequencia = gameObject.GetComponent<SequenciaAtiva>();
    }



    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.GetComponent<NumeroBola>().numeroDaBola == sequencia.getProximo()){
            int numero = other.GetComponent<NumeroBola>().numeroDaBola;
            

            bola = bolaPrefab;
            bola.GetComponent<NumeroBola>().numeroDaBola = numero;
            bola = Instantiate(bola, posicaoInicial, Quaternion.identity);

            sequencia.updateProximo();

        }
        else
        {
            int numero = other.GetComponent<NumeroBola>().numeroDaBola;
            
            Destroy(other.gameObject);
            bola = bolaPrefab;
            bola.GetComponent<NumeroBola>().numeroDaBola = numero;
            bola = Instantiate(bola, posicaoInicial, Quaternion.identity);
            
        }

    }
    
    IEnumerator WaitBall()
    {
        yield return new WaitForSeconds(5);
    }
}
