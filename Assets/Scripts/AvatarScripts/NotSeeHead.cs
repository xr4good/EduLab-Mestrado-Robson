using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotSeeHead : MonoBehaviour
{
    [SerializeField] private List<GameObject> NotSeeByMe;
    public string IgnoreLayer;


    // Start is called before the first frame update
    public void changeLayer()
    {
        for (int i = 0; i < NotSeeByMe.Count; i++)
        {
            int LayerIgnoreRaycast = LayerMask.NameToLayer(IgnoreLayer);
            GameObject notsee = NotSeeByMe[i];
            notsee.layer = LayerIgnoreRaycast;
        }
    }
}

    
