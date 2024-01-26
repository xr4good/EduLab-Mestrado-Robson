
using System.Collections;
using UnityEngine;

public class MoveToLab : MonoBehaviour
{
    [SerializeField] Vector3 posicao1;
    [SerializeField] Vector3 posicao2junto;
    [SerializeField] Vector3 posicao2separado;

    
    private bool first = true;

    public void LoadScene()
    {
        StartCoroutine(aoPressionar());
    }

    IEnumerator aoPressionar()
    {
        yield return new WaitForSeconds(2);
        GameObject XR = GameObject.FindGameObjectWithTag("Player");
        
        if ( first)
        {           
            XR.transform.position = posicao1;
            first = false;
            TimeCounter time = GameObject.FindObjectOfType<TimeCounter>();
            time.StartCounter();
        }
        else
        {            
            if (SetGameConfig.JUNTO)
            {
                XR.transform.position = posicao2junto;
            }
            else
            {
                XR.transform.position = posicao2separado;
            }
            
        }       
    }

}
