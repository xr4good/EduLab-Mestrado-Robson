using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FixTeleportAreas : MonoBehaviour
{
    [SerializeField] private UnityEngine.XR.Interaction.Toolkit.Locomotion.Teleportation.TeleportationProvider teleportationProvider;
    void Start()
    {
        foreach (UnityEngine.XR.Interaction.Toolkit.Locomotion.Teleportation.TeleportationArea obj in FindObjectsOfType<UnityEngine.XR.Interaction.Toolkit.Locomotion.Teleportation.TeleportationArea>())
        {
            obj.teleportationProvider = teleportationProvider;
        }
    }
}

