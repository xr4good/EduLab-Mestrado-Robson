using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumeroBola : MonoBehaviour
{

    public int numeroDaBola;
    [SerializeField] Material mat1;
    [SerializeField] Material mat2;
    [SerializeField] Material mat3;
    [SerializeField] Material mat4;
    [SerializeField] Material mat5;
    [SerializeField] Material mat6;
    [SerializeField] Material mat7;
    private Material mat;

    // Start is called before the first frame update
    void Start()
    {
        setColor(numeroDaBola);        
    }


    void setColor(int n)
    {
        switch (n)
        {
                case 0:
                mat = mat1;
                break;
                case 1:
                mat = mat2;
                break;
                case 2:
                mat = mat3;
                break;
                case 3:
                mat = mat4;
                break;
                case 4:
                mat = mat5;
                break;      
                case 5:
                mat = mat6;
                break;
                case 6:
                mat = mat7;
                break;
                default:
                mat = mat1;
                break;


        }
        GetComponent<Renderer>().material = mat;
    }
}
