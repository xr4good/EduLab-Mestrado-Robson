using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereFall : MonoBehaviour
{
    public Vector3 posicaoInicial;
    public int numeroDaBola;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -7.3)
        {
            transform.position = posicaoInicial;
        }
        /*
        if( transform.position.x > posicaoInicial.x + 0.226f ||
            transform.position.x < posicaoInicial.x - 0.721f )
            
        {
            transform.position = posicaoInicial;
        }*/
    }
}
