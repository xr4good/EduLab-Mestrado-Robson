using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCorreto : MonoBehaviour
{
    
    public List<GameObject> bolaPrefabs;   
    //private GameObject bola;
    [SerializeField] private Vector3 posicaoInicial;
    public SequenciaAtiva sequencia;
    [SerializeField] ParticleSystem smoke;

    private void Start()
    {
        smoke.Stop();
        //sequencia = gameObject.GetComponent<SequenciaAtiva>();
    }



    private void OnTriggerEnter(Collider other)
    {
        int numero = other.GetComponent<NumeroBola>().numeroDaBola;
        if (numero == sequencia.getProximo()){

            //Debug.Log("Número da Bola:" +  numero);
            //bola = bolaPrefab;
            //bola.GetComponent<NumeroBola>().numeroDaBola = numero;
            Instantiate(bolaPrefabs[numero-1], posicaoInicial, Quaternion.identity);

            sequencia.updateProximo();

        }
        else
        {
            
            smoke.Play();
            Destroy(other.gameObject);
            //bola = bolaPrefab;
            //bola.GetComponent<NumeroBola>().numeroDaBola = numero;
            Instantiate(bolaPrefabs[numero-1], posicaoInicial, Quaternion.identity);
            
        }

    }
    
    IEnumerator WaitBall()
    {
        yield return new WaitForSeconds(5);
    }
}
