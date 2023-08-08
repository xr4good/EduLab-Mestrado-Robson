using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereFall : MonoBehaviour
{
    public Vector3 posicaoInicial;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -7.3)
        {
            transform.position = posicaoInicial;
        }
    }
}
