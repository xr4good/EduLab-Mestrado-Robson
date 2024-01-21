using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubirBalão : MonoBehaviour
{
    [SerializeField] private float posicaoFinal;
    [SerializeField] private float valor = 0.000001f;
    

    // Update is called once per frame
    void Update()
    {
        while (transform.position.y < posicaoFinal)
        {
            transform.position = new Vector3 (transform.position.x, transform.position.y + valor, transform.position.z);
        }
        
    }
}
