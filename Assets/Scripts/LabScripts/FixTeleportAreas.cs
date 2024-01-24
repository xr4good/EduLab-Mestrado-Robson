using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.Interaction.Toolkit;

public class FixTeleportAreas : MonoBehaviour
{
    [SerializeField] private TeleportationProvider teleportationProvider;
    void Start()
    {
        foreach (TeleportationArea obj in FindObjectsOfType<TeleportationArea>())
        {
            obj.teleportationProvider = teleportationProvider;
        }
    }
}

