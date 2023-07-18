using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciarExercicio : MonoBehaviour
{
    public Tree[] arbustosAltos;
    public Tree[] arbustosBaixos;
    public int totalAltos = 0;
    public int totalBaixos = 0;


    // Start is called before the first frame update
    public void RandomizarArbustos()
    {
        for (int i = 0; i < totalAltos; i++)
        {
            SpawnAltos();
        }

        for (int i = 0; i < totalBaixos; i++)
        {
            SpawnBaixos();
        }
    }


    private void SpawnAltos()
    {
        float pox = Random.Range(4.0f, 6.0f);
        float poz = Random.Range(-17.0f, -15.0f);
        Vector3 newVector = new Vector3(pox, 6.0f, poz);
        Instantiate(arbustosAltos[Random.Range(0, arbustosAltos.Length)], newVector, transform.rotation);
    }
    private void SpawnBaixos()
    {
        float pox = Random.Range(4.0f, 6.0f);
        float poz = Random.Range(-17.0f, -15.0f);
        Vector3 newVector = new Vector3(pox, 6.0f, poz);
        Instantiate(arbustosBaixos[Random.Range(0, arbustosBaixos.Length)], newVector, transform.rotation);
    }

    public void SetTotalAltos(int altos)
    {
        totalAltos = altos;
        
    }
    public void SetTotalBaixos( int baixos)
    {
        
        totalBaixos = baixos;
    }

    public void DestroyArbustos()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Arbusto");
        foreach (GameObject item in gos)
        {
            Destroy(item);
        }
    }
}
