using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ContTrigBlock : MonoBehaviour
{
    ActionBasedController controller_L;
    ActionBasedController controller_R;

    ActionBasedController[] controllers;

    Collider L_Collider;
    Collider R_Collider;

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

        L_Collider= controller_L.GetComponent<Collider>();
        R_Collider= controller_R.GetComponent<Collider>();
    }
    private void Update()
    {
        if (TagDetecter.hoverTag != 40 && TagDetecter.hoverTag != 41 && TagDetecter.hoverTag != 55)
        {
            if (controller_L.selectAction.action.ReadValue<float>() > 0)
            {
                L_Collider.enabled = false;
            }
            else
                L_Collider.enabled = true;

            if (controller_R.selectAction.action.ReadValue<float>() > 0)
            {
                R_Collider.enabled = false;
            }
            else
                R_Collider.enabled = true;
        }
    }
}
