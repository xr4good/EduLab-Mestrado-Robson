using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcenderLampada : MonoBehaviourPunCallbacks
{
    public Material lampadaApagada;
    public Material lampadaAcesa;
  

    public void Acender()
    {
        this.photonView.RPC("AcenderLuz", RpcTarget.All);
       
    }

    [PunRPC]
     IEnumerator AcenderLuz()
    {
            transform.GetComponent<MeshRenderer>().material = lampadaAcesa;
            yield return new WaitForSeconds(5);
             transform.GetComponent<MeshRenderer>().material = lampadaApagada;
    }


}
