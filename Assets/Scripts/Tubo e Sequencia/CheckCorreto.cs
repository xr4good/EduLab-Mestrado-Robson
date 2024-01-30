using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CheckCorreto : MonoBehaviourPunCallbacks
{
    public SequenciaAtiva sequencia;
    [SerializeField] ParticleSystem smoke;
    public TrocaPonto trocaPonto;
    private StatementSender statementSender;
    public string pasta;
    public bool correto = false;

    private void Start()
    {
        smoke.Stop();
        statementSender = GameObject.FindObjectOfType<StatementSender>();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PhotonView>().IsMine)
        {
            if (other.gameObject.tag.Equals("Sphere"))
            {
                other.isTrigger = false;
                int numero = other.GetComponent<SphereFall>().numeroDaBola;
                Vector3 posicaoInicial = other.GetComponent<SphereFall>().posicaoInicial;
                if (numero == sequencia.getProximo())
                {

                    if (!other.GetComponent<XRGrabInteractable>().isSelected)
                    {
                        //cria uma nova esfera no lugar inicial e atualiza a sequencia de bolas
                        PhotonNetwork.InstantiateRoomObject(Path.Combine(pasta, "Sphere " + numero), posicaoInicial, Quaternion.identity);
                        sequencia.updateProximo();

                        //tira a possibilidade de segurar a bolinha inserida no tubo
                        other.GetComponent<XRGrabInteractable>().enabled = false;

                        //atualiza o quadro de pontos
                        trocaPonto.TrocarPontos(10, true);

                        //informa a LRS
                        if (sequencia.concluido)
                        {
                            statementSender.SendStament("Bola", numero.ToString(), true, true);
                        }
                        else
                        {
                            statementSender.SendStament("Bola", numero.ToString(), true, false);
                        }


                    }

                }
                else
                {
                    // ativa animação, destroi o objeto e cria uma nova esfera no lugar de origem
                    this.photonView.RPC("PlaySmoke", RpcTarget.All);
                    PhotonNetwork.Destroy(other.gameObject);
                    PhotonNetwork.InstantiateRoomObject(Path.Combine(pasta, "Sphere " + numero), posicaoInicial, Quaternion.identity);

                    //atualiza o quadro de pontos
                    trocaPonto.TrocarPontos(10, false);

                    //informa a LRS
                    statementSender.SendStament("Bola", numero.ToString(), false, false);
                }
            }
        }       
    }

    [PunRPC]
    void PlaySmoke()
    {
        smoke.Play();
    }

    [PunRPC]
    void DestroyObject(GameObject obj)
    {
        Destroy(obj);
    }

}
