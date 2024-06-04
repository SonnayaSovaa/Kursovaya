using System;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
public class PlayerImput : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private InputActionProperty _gripAction;
    [SerializeField] private InputActionProperty _triggerAction;
    private bool flag = true;
    public int tagg;

    [SerializeField] Weap_Desc weap;

    ActionBasedController[] controllers;
    public ActionBasedController controller_L;
    public ActionBasedController controller_R;

    private void Start()
    {
        controllers = FindObjectsOfType<ActionBasedController>();
        if (controllers[0].tag == "Right")
        {
            controller_R = controllers[0];
            controller_L = controllers[1];
        }
        else
        {
            controller_L = controllers[0];
            controller_R = controllers[1];
        }
    }

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("1") || other.tag.Contains("2") || other.tag.Contains("3") || other.tag.Contains("4") ||
            other.tag.Contains("5") || other.tag.Contains("6") || other.tag.Contains("7") || other.tag.Contains("8") ||
            other.tag.Contains("9") || other.tag.Contains("0"))
        {
            tagg = Convert.ToInt32(other.tag);

            if (0 <= tagg && tagg< 37)
            {
                StartCoroutine(weap.InHand());
            }
        }
    }

    public void OnTriggerStay(Collider other)
    {

        if (other.tag.Contains("1") || other.tag.Contains("2") || other.tag.Contains("3") || other.tag.Contains("4") || other.tag.Contains("5") || other.tag.Contains("6") || other.tag.Contains("7") || other.tag.Contains("8") || other.tag.Contains("9") || other.tag.Contains("0"))
        {
            flag = false;
            _animator.SetFloat("Grip", 0);
            _animator.SetFloat("Trigger", 0);
            int objtag = Convert.ToInt32(other.tag);
            switch (objtag)
            {
                case 37:
                    _animator.SetBool("Key", true);
                    break;
                case 38:
                    _animator.SetBool("Hill", true);
                    break;
                default:
                    _animator.SetBool("Wep", true);
                    break;
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        flag = true;
        _animator.SetBool("Hill", false);
        _animator.SetBool("Key", false);
        _animator.SetBool("Wep", false);


        if (this.tag == "R" && other.gameObject.GetNamedChild("[Right Controller] Dynamic Attach") !=null|| this.tag == "L" && other.gameObject.GetNamedChild("[Left Controller] Dynamic Attach") != null)
        {
            
            if (0 <= tagg && tagg < 37)
            {
                StartCoroutine(weap.OutHand());
            }
        }

    }
}

