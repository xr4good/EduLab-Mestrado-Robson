using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CheckCorreto : MonoBehaviour
{
    
    public List<GameObject> bolaPrefabs; 
    public SequenciaAtiva sequencia;
    [SerializeField] ParticleSystem smoke;
    public TrocaPonto trocaPonto;

    private void Start()
    {
        smoke.Stop();
        
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Sphere"))
        {
            int numero = other.GetComponent<NumeroBola>().numeroDaBola;
            Vector3 posicaoInicial = other.GetComponent<SphereFall>().posicaoInicial;
            if (numero == sequencia.getProximo())
            {

                if (!other.GetComponent<XRGrabInteractable>().isSelected)
                {
                    Instantiate(bolaPrefabs[numero - 1], posicaoInicial, Quaternion.identity);
                    sequencia.tuboList.Add(other.gameObject);
                    sequencia.updateProximo();

                    other.GetComponent<XRGrabInteractable>().enabled = false;
                    trocaPonto.TrocarPontos(10, true);

                }

            }
            else
            {

                smoke.Play();
                Destroy(other.gameObject);
                Instantiate(bolaPrefabs[numero - 1], posicaoInicial, Quaternion.identity);

                trocaPonto.TrocarPontos(10, false);
            }
        }
       

    }

}
