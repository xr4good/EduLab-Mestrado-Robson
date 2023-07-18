using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class InputToTransform : MonoBehaviour
{

    [SerializeField]
    InputActionProperty m_PositionAction;

    public InputActionProperty positionAction
    {
        get => m_PositionAction;
        set => SetInputActionProperty(ref m_PositionAction, value);
    }

    [SerializeField]
    InputActionProperty m_RotationAction;
    /// <summary>
    /// The Input System action to use for Rotation Tracking for this GameObject. Must be a <see cref="QuaternionControl"/> Control.
    /// </summary>
    public InputActionProperty rotationAction
    {
        get => m_RotationAction;
        set => SetInputActionProperty(ref m_RotationAction, value);
    }

    void SetInputActionProperty(ref InputActionProperty property, InputActionProperty value)
    {
        if (Application.isPlaying)
            property.DisableDirectAction();

        property = value;

        if (Application.isPlaying && isActiveAndEnabled)
            property.EnableDirectAction();
    }

    protected void UpdatePosition()
    {
        var posAction = m_PositionAction.action;
        var rotAction = m_RotationAction.action;

        // Update position
           
        transform.position = posAction.ReadValue<Vector3>();
        transform.rotation = rotAction.ReadValue<Quaternion>();
        
    }

    private void LateUpdate()
    {
        UpdatePosition();
    }
}