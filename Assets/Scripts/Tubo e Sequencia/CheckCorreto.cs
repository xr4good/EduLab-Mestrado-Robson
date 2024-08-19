using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class CheckCorreto : MonoBehaviourPunCallbacks
{
    public SequenciaAtiva sequencia;
    [SerializeField] ParticleSystem smoke;
    public TrocaPonto trocaPonto;
    private StatementSender statementSender;
    public string pasta;
    public bool correto = false;

    public string tag;

    private void Start()
    {
        smoke.Stop();
        statementSender = GameObject.FindObjectOfType<StatementSender>();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals(tag))
        {
            if (other.GetComponent<PhotonView>().IsMine)
            {
                other.isTrigger = false;
                int numero = other.GetComponent<SphereFall>().numeroDaBola;
                Vector3 posicaoInicial = other.GetComponent<SphereFall>().posicaoInicial;
                if (numero == sequencia.getProximo())
                {

                    if (!other.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>().isSelected)
                    {
                        //cria uma nova esfera no lugar inicial e atualiza a sequencia de bolas
                        PhotonNetwork.Instantiate(Path.Combine(pasta, "Sphere " + numero), posicaoInicial, Quaternion.identity);
                        sequencia.updateProximo();

                        //tira a possibilidade de segurar a bolinha inserida no tubo
                        other.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>().enabled = false;

                        //atualiza o quadro de pontos
                        trocaPonto.TrocarPontos(10, true);

                        //informa a LRS
                        if (sequencia.concluido)
                        {
                            statementSender.SendStament("Colocou Bola", numero.ToString(), true, true);
                        }
                        else
                        {
                            statementSender.SendStament("Bola", numero.ToString(), true, false);
                        }


                    }

                }
                else
                {
                    // ativa anima��o, destroi o objeto e cria uma nova esfera no lugar de origem
                    this.photonView.RPC("PlaySmoke", RpcTarget.All);
                    PhotonNetwork.Destroy(other.gameObject);
                    PhotonNetwork.Instantiate(Path.Combine(pasta, "Sphere " + numero), posicaoInicial, Quaternion.identity);

                    //atualiza o quadro de pontos
                    trocaPonto.TrocarPontos(2, false);

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
