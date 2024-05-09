using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ContTrigBlock : MonoBehaviour
{
    [SerializeField] ActionBasedController controller_L;
    [SerializeField] ActionBasedController controller_R;

    [SerializeField] Collider L_Collider;
    [SerializeField] Collider R_Collider;


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
