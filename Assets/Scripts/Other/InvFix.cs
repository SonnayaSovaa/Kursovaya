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
        
        changed = ForButton.chek;

        if (changed!=was_changed)
        {
            Fix(changed);
            was_changed = changed;

        }
    }

    private void Awake()
    {
        (this.GetComponent("XRSocketInteractor") as MonoBehaviour).enabled = false;        
    }

    public void Fix(bool stat)
    {
        if (stat==false)
        {
            if (this.tag == "Svoboden")
            {                
                (this.GetComponent("XRSocketInteractor") as MonoBehaviour).enabled = false;
            }
            
            else
            {
                currobj.SetActive(false);
            }

        }
        else
        {
            if (this.tag == "Svoboden")
            {
                (this.GetComponent("XRSocketInteractor") as MonoBehaviour).enabled = true;
            }
            else
            {
                currobj.SetActive(true);
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "38" || other.tag == "39")
        {

            currobj = other.gameObject;
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
