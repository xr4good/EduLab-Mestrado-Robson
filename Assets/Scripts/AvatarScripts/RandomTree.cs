using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTree : MonoBehaviour
{
    public Tree[] trees;
    public int totalTree2 = 18;
    public int totalTree3 = 80;
    public int totalTree1 = 60;
    
    

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < totalTree1; i++)
        {
            SpawnTree1();
        }

        for (int i = 0; i < totalTree3; i++)
        {
            SpawnTree3();
        }

          for(int i=0; i<totalTree2; i++)
        {
            SpawnTree2();
            SpawnTree4();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void SpawnTree1()
    {
        float pox = Random.Range(28, 82);
        float poz = Random.Range(-18, 50);
        Vector3 newVector = new Vector3(pox, 6, poz);
        Instantiate(trees[Random.Range(0, trees.Length)], newVector, transform.rotation);
    }
    void SpawnTree2()
    {
        float pox = Random.Range(-48, 28);
        float poz = Random.Range(23, 36);
        Vector3 newVector = new Vector3(pox, 6, poz);
        Instantiate(trees[Random.Range(0, trees.Length)], newVector, transform.rotation);
    }
    void SpawnTree3()
    {
        float pox = Random.Range(-110, -78);
        float poz = Random.Range(-49, 38);
        Vector3 newVector = new Vector3(pox, 6, poz);
        Instantiate(trees[Random.Range(0, trees.Length)], newVector, transform.rotation);
    }

    void SpawnTree4()
    {
        float pox = Random.Range(-48, 28);
        float poz = Random.Range(50, 60);
        Vector3 newVector = new Vector3(pox, 6, poz);
        Instantiate(trees[Random.Range(0, trees.Length)], newVector, transform.rotation);
    }

    
}
