using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToogleImage : MonoBehaviour
{

    public MeshRenderer mesh;
    public Material seCorpo;
    public Material sePC;
    GameDefinitions gameDefinitions;

    // Start is called before the first frame update
    void Awake()
    {
        gameDefinitions = FindObjectOfType<GameDefinitions>();

        if (gameDefinitions.CORPO)
        {
            mesh.material = seCorpo;
        }
        else
        {
            mesh.material = sePC;
        }

    }
}
