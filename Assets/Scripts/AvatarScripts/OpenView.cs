using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenView : MonoBehaviour
{
    public GameObject view;
    // Start is called before the first frame update


    // Update is called once per frame
    public void ActivateView()
    {
            view.SetActive(true);
    }

    public void DesactivateView()
    {
        view.SetActive(true);
    }
}
