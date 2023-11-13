
using UnityEngine;

public class MoveToLab : MonoBehaviour
{
    [SerializeField] Vector3 posicao1;
    [SerializeField] Vector3 posicao2;
    [SerializeField] Vector3 posicao3;

    public bool isDupla = false;

    private void Start()
    {
        isDupla = SetGameConfig.JUNTO;
    }

    public void Teleporte()
    {
        GameObject XR = GameObject.FindGameObjectWithTag("Player");
        ActiveAvatar activeAvatar = XR.GetComponent<ActiveAvatar>();

        if (isDupla)
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
    }
}
