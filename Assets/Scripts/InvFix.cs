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
        //Debug.Log("changed + "+changed+"curr + "+currobj);

        changed = ForButton.SetInv;
        if (changed!=was_changed)
        {
            Fix(changed);
            was_changed = changed;

            Debug.Log("STAT "+ (this.GetComponent("XRSocketInteractor") as MonoBehaviour).enabled);
        }
    }

    private void Awake()
    {
        //(this.GetComponent("XRSocketInteractor") as MonoBehaviour).enabled = false;
        //this.gameObject.SetActive(false);
    }

    public void Fix(bool stat)
    {

        if (stat == false)
        {
            if (this.tag == "Svoboden")
            {
                this.gameObject.SetActive(false);
                //(this.GetComponent("XRSocketInteractor") as MonoBehaviour).enabled = false;
            }
            else
            {
                //currobj.gameObject.transform.parent = this.gameObject.transform;
                //currobj.gameObject.transform.position = this.transform.position;
                currobj.SetActive(false);
            }

        }
        else
        {

            currobj.SetActive(true);
            if (this.tag == "Svoboden")
            {
                //(this.GetComponent("XRSocketInteractor") as MonoBehaviour).enabled = true;
                this.gameObject.SetActive(true);
            }
            else
            {
                currobj.SetActive(true);
                //currobj.gameObject.transform.parent = null;
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
            currobj = null;
        }
    }

}
