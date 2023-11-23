
using System.Collections;
using UnityEngine;

public class MoveToLab : MonoBehaviour
{
    [SerializeField] Vector3 posicao1;
    [SerializeField] Vector3 posicao2junto;
    [SerializeField] Vector3 posicao2separado;

    public GameObject load1;
    public GameObject load2;

   
    /*public void Teleporte()
    {
        GameObject XR = GameObject.FindGameObjectWithTag("Player");
        ActiveAvatar activeAvatar = XR.GetComponent<ActiveAvatar>();

        if (SetGameConfig.JUNTO)
        {
            if (activeAvatar.player.Equals("Player1"))
            {
                XR.transform.position = posicao1;
            }
            else if (activeAvatar.player.Equals("Player2"))
            {
                XR.transform.position = posicao2;
            }
        }
        else
        {
            if (activeAvatar.player.Equals("Player1"))
            {
                XR.transform.position = posicao1;
            }
            else if(activeAvatar.player.Equals("Player2"))
            {
                XR.transform.position = posicao3;
            }
        }
    }*/

    public void LoadScene1()
    {
        StartCoroutine(aoPressionar1());
    }
    public void LoadScene2()
    {
        StartCoroutine(aoPressionar2());
    }

    IEnumerator aoPressionar2()
    {
        yield return new WaitForSeconds(2);
        GameObject XR = GameObject.FindGameObjectWithTag("Player");
        ActiveAvatar activeAvatar = XR.GetComponent<ActiveAvatar>();
        if (SetGameConfig.JUNTO)
        {
            XR.transform.position = posicao2junto;
        }
        else
        {
            XR.transform.position = posicao2separado;
        }
        load2.SetActive(false);

    }

    IEnumerator aoPressionar1()
    {
        yield return new WaitForSeconds(2);
        GameObject XR = GameObject.FindGameObjectWithTag("Player");
        ActiveAvatar activeAvatar = XR.GetComponent<ActiveAvatar>();
        XR.transform.position = posicao1;
        load1.SetActive(false);
    }
}
