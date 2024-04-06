using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonCheck : MonoBehaviour
{
    public ActionBasedController controller_R;
    void Update()
    {
        ActionBasedController[] controllerArray = ActionBasedController.FindObjectsOfType<ActionBasedController>();

        ActionBasedController controller_L = controllerArray[0];
        //ActionBasedController controller_R = controllerArray[1];
       

        if (controller_R.selectAction.action.ReadValue<float>()>0)
        {
            Debug.Log("Right GRIP"); 
        }

    }
}
