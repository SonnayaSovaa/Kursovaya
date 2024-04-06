using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.CoreUtils;
using Unity.VisualScripting;

public class Inventory : MonoBehaviour
{
    public GameObject canvas;
    bool a;




    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("TRIG");


        GameObject currObj = other.gameObject;
        a = (currObj.GetNamedChild("[Right Controller] Dynamic Attach") || currObj.GetNamedChild("[Left Controller] Dynamic Attach"));

        Debug.Log(a);
        if (!a)
        {
            if (other.tag == "38" || other.tag == "39")
            {
                if (this.tag == "Svoboden")
                {

                    currObj.transform.parent = this.gameObject.transform;

                    other.isTrigger = true;

                    currObj.transform.position = this.transform.position;
                    //(currObj.GetComponent("XRGrabInteractable") as MonoBehaviour).enabled = false;

                    Rigidbody rigidbody = currObj.GetComponent<Rigidbody>();
                    rigidbody.useGravity = false;

                    this.tag = "Zanyat";
                    //(currObj.GetComponent("XRGrabInteractable") as MonoBehaviour).enabled = true;
                }

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "38" || other.tag == "39")
            this.gameObject.tag = "Svoboden";
    }


}
