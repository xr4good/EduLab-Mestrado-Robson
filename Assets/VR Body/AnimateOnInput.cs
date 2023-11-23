using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class AnimationInput
{
    public string animationPropertyName;
    public InputActionProperty action;
}

public class AnimateOnInput : MonoBehaviour
{
    public List<AnimationInput> animationInputs;
    //public Vector3 position;
    public Animator animator;
    public GameObject self;
    public ActiveAvatar ativeAvatar;
    
    // Update is called once per frame
    void Update()
    {
       
        if (ativeAvatar != null && ativeAvatar.avatar.Equals(self))
        {
            foreach (var item in animationInputs)
            {
                float actionValue = item.action.action.ReadValue<float>();
                animator.SetFloat(item.animationPropertyName, actionValue);
            }
        }
        

        //animator.SetFloat("Forward", position.normalized.x);
    }
}
