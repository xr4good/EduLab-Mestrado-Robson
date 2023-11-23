using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciaBola : MonoBehaviour
{
    public GameObject bolaPrefab;
    private GameObject bola;
    public GameObject posicaoInicial;

    private IEnumerator coroutine;

    // Start is called before the first frame update
    public void StartGame()
    {                    
            coroutine = Wait(1.0f, 7);
            StartCoroutine(coroutine);
        
    }

    IEnumerator Wait(float waitTime, int repetions)
    {
        int n = 0;
        while (n < repetions)
        {
            bola = bolaPrefab;
            bola.GetComponent<NumeroBola>().numeroDaBola = n;
            bola = Instantiate(bola, posicaoInicial.transform.position, Quaternion.identity);
            n++;
            yield return new WaitForSeconds(waitTime);

        }        
    }

}
