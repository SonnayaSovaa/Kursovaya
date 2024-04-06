using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerImput : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private InputActionProperty _gripAction;
    [SerializeField] private InputActionProperty _triggerAction;
    void Update()
    {
        var gripvalue = _gripAction.action.ReadValue<float>();
        var activationvalue = _triggerAction.action.ReadValue<float>();
        _animator.SetFloat("Grip",gripvalue);
        _animator.SetFloat("Trigger", activationvalue);

         if(TagDetecter.hoverTag==38)
        {
            _animator.SetFloat("Grip", gripvalue);
            //Debug.Log("heal");
        }
         else
        {
            if (TagDetecter.hoverTag == 39)
            {
                _animator.SetFloat("Grip", gripvalue);
                //Debug.Log("key");
            }
            else
            {
                _animator.SetFloat("Grip", gripvalue);
                //Debug.Log("weapon");
            }
        }
    }
}
