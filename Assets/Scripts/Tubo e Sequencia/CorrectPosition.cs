using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectPosition : MonoBehaviour
{
    public Material branco;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sphere" )
        {
            StartCoroutine (piscar(other));
        }
    }

    IEnumerator piscar (Collider other)
    {
        
        Material aux = other.GetComponent<MeshRenderer>().material;
        other.GetComponent<MeshRenderer>().material = branco;
        yield return new WaitForSeconds(0.2f);
        other.GetComponent<MeshRenderer>().material = aux;
        yield return new WaitForSeconds(0.2f);
        other.GetComponent<MeshRenderer>().material = branco;
        yield return new WaitForSeconds(0.2f);
        other.GetComponent<MeshRenderer>().material = aux;
        
    }
}
