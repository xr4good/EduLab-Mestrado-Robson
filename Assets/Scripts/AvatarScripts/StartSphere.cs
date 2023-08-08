using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSphere : MonoBehaviour
{

    [SerializeField] List<GameObject> sphereList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < sphereList.Count; i++)
        {
            Vector3 pos = sphereList[i].GetComponent<SphereFall>().posicaoInicial;
            Instantiate(sphereList[i], pos, Quaternion.identity);
        }
    }
}

  
