using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerImput : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private InputActionProperty _gripAction;
    [SerializeField] private InputActionProperty _triggerAction;
    private bool flag=true;
    void Update()
    {
        if (flag)
        {
            var gripvalue = _gripAction.action.ReadValue<float>();
            var activationvalue = _triggerAction.action.ReadValue<float>();
            _animator.SetFloat("Grip", gripvalue);
            _animator.SetFloat("Trigger", activationvalue);
        }
}
   public void OnTriggerStay(Collider other)
    {
        if (other.tag.Contains("1") || other.tag.Contains("2") || other.tag.Contains("3") || other.tag.Contains("4") ||
            other.tag.Contains("5") || other.tag.Contains("6") || other.tag.Contains("7") || other.tag.Contains("8") ||
            other.tag.Contains("9") || other.tag.Contains("0"))
        {
            flag = false;
            int tag = Convert.ToInt32(other.tag);
            switch (tag)
            {
                case 37:
                    _animator.SetBool("Key", true);
                    break;
                case 38: 
                    _animator.SetBool("Hill", true); 
                    break;
                default:
                    _animator.SetBool("Wep",true);
                    break;
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        flag=true;
        _animator.SetBool("Hill", false);
        _animator.SetBool("Key", false);
        _animator.SetBool("Wep",false);
    }
}
