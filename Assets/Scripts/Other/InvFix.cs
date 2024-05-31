using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Assertions.Must;

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
                this.GetComponent<Collider>().enabled = false;
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
                this.GetComponent<Collider>().enabled = true;
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

        //if (currobj.GetNamedChild("[point] Dynamic Attach")) this.GetComponent<Collider>().enabled = false;
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
