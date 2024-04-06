using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR;
using UnityEngine.XR.OpenXR.Features.Interactions;
using Unity.XR.Oculus.Input;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.OpenVR;

public class Rayyy : MonoBehaviour
{

    public ActionBasedController controller_L;
    public ActionBasedController controller_R;

    public void OnTriggerStay(Collider other)
    {
        if (TagDetecter.hoverTag == 38 && other.isTrigger)
        {

            if ((this.gameObject.tag == "Left" && controller_L.selectAction.action.ReadValue<float>() > 0) || (this.gameObject.tag == "Right" && controller_R.selectAction.action.ReadValue<float>() > 0))
            {

                Debug.Log("trig");
               

                GameObject currObj = other.gameObject;
                currObj.transform.parent = null;

                other.isTrigger = false;

                Rigidbody rigidbody = currObj.GetComponent<Rigidbody>();
                rigidbody.useGravity = true;
                
            }
        }

    }
}

 

