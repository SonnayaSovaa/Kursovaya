using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.CoreUtils;

public class Inventory : MonoBehaviour
{
    public GameObject canvas;

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("TRIG");

        GameObject currObj = other.gameObject;
        if (!(currObj.GetNamedChild("[Right Controller] Dynamic Attach") || currObj.GetNamedChild("[Left Controller] Dynamic Attach")))
        {
            if (other.tag=="38")
            {
                if (this.tag == "Svoboden")
                {

                    currObj.transform.parent = canvas.transform;

                    other.isTrigger = true;

                    currObj.transform.position = this.transform.position;

                    Rigidbody rigidbody = currObj.GetComponent<Rigidbody>();
                    rigidbody.useGravity = false;
                    this.tag = "Zanyat";
                }
                
            }
        }
    }


}
