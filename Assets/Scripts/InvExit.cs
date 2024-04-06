using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class InvExit: MonoBehaviour
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
                //(currObj.GetComponent("XRGrabInteractable") as MonoBehaviour).enabled = true;
                other.isTrigger = false;
                
                Rigidbody rigidbody = currObj.GetComponent<Rigidbody>();
                rigidbody.useGravity = true;
                currObj.transform.parent = null;

                



            }
        }

    }
}

 

