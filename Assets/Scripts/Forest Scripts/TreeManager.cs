using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class TreeManager : MonoBehaviour
{
    private Rigidbody treeRb;
    public int totalLeaf = 20;
    public GameObject[] leaves;
    



    // Start is called before the first frame update
    void Start()
    {
        treeRb = GetComponent<Rigidbody>();

    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            for (int i = 0; i < totalLeaf; i++)
            {
                SpawnLeaf();

            }
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < totalLeaf; i++)
            {
                SpawnLeaf();
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnLeaf()
    {
        float pox = Random.Range(-5, 5);
        float poz = Random.Range(-5, 5);
        float poy = Random.Range(10, 15);
        Vector3 newVector = new Vector3(pox, poy, poz);


        Instantiate(leaves[Random.Range(0, leaves.Length)], treeRb.position + newVector, transform.rotation);


    }
}
