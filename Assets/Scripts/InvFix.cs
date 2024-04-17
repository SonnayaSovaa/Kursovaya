using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvFix : MonoBehaviour
{
    [SerializeField] GameObject inv;
    GameObject currobj=null;

    bool changed=false;
    bool was_changed=false;

    private void Update()
    {
        Debug.Log("changed + "+changed+"curr + "+currobj);

        changed = ForButton.SetInv;
        if (changed!=was_changed)
        {
            Fix(changed);
            was_changed = changed;
        }
    }

    public void Fix(bool stat)
    {
        if (!(currobj is null))
        {
            if (stat == false)
            {
                currobj.gameObject.transform.parent = this.gameObject.transform;
                currobj.gameObject.transform.position = this.transform.position;
                currobj.SetActive(false);
            }
            else
            {
                currobj.gameObject.transform.parent = null;
                currobj.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "38" || other.tag == "39")
        {

            currobj = other.gameObject;

            //Rigidbody rigidbody = other.gameObject.GetComponent<Rigidbody>();
            //rigidbody.useGravity = false;

            this.tag = "Zanyat";

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "38" || other.tag == "39")
        {
            this.tag = "Svoboden";
        }
    }

}
