using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

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
        
        
           /* _animator.SetBool("Hill", false);
            _animator.SetBool("Key", false);
            _animator.SetFloat("Grip",gripvalue);
            _animator.SetFloat("Trigger", activationvalue);
            
                _animator.SetBool("Hill", true);
                //Debug.Log("heal");
           
                    _animator.SetBool("Key", true);
                    //Debug.Log("key");
                _animator.SetFloat("Grip", gripvalue);
                    //Debug.Log("weapon");*/
                
    }
}
