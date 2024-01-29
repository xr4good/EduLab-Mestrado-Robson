using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CheckCorreto : MonoBehaviourPunCallbacks
{
    
    public List<GameObject> bolaPrefabs; 
    public SequenciaAtiva sequencia;
    [SerializeField] ParticleSystem smoke;
    public TrocaPonto trocaPonto;
    private StatementSender statementSender;
    

    private void Start()
    {
        smoke.Stop();
        statementSender = GameObject.FindObjectOfType<StatementSender>();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Sphere"))
        {
            int numero = other.GetComponent<SphereFall>().numeroDaBola;
            Vector3 posicaoInicial = other.GetComponent<SphereFall>().posicaoInicial;
            if (numero == sequencia.getProximo())
            {

                if (!other.GetComponent<XRGrabInteractable>().isSelected)
                {
                    //cria uma nova esfera no lugar inicial e atualiza a sequencia de bolas
                    Instantiate(bolaPrefabs[numero - 1], posicaoInicial, Quaternion.identity);
                    sequencia.tuboList.Add(other.gameObject);
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
                Destroy(other.gameObject);
                Instantiate(bolaPrefabs[numero - 1], posicaoInicial, Quaternion.identity);
                
                //atualiza o quadro de pontos
                trocaPonto.TrocarPontos(10, false);

                //informa a LRS
                statementSender.SendStament("Bola", numero.ToString(), false, false);
            }
        }
       

    }

    [PunRPC]
    void PlaySmoke()
    {
        smoke.Play();
    }

}
