using Photon.Pun;
using System.IO;
using UnityEngine;


[System.Serializable]
public class ballPosition
{
    public GameObject sphere;
    public SphereFall  posicaoInicial;
    public string pasta;
    public string numero;
    
    

    public void InstaciateSphere()
    {
        PhotonNetwork.Instantiate(Path.Combine(pasta, "Sphere " + numero), posicaoInicial.posicaoInicial, Quaternion.identity);
    }


}
public class StartSphere : MonoBehaviourPunCallbacks
{
    [SerializeField] public ballPosition sphere1;
    [SerializeField] public ballPosition sphere2;
    [SerializeField] public ballPosition sphere3;
    [SerializeField] public ballPosition sphere4;

    public string tag;

    public void CreateSpheres()
    {
        sphere1.InstaciateSphere();
        sphere2.InstaciateSphere();
        sphere3.InstaciateSphere();
        sphere4.InstaciateSphere();
    }

    private void Start()
    {
        if(GameObject.FindGameObjectsWithTag(tag).Length == 0)
        {
            CreateSpheres();

        } 
        
    }

}


  
