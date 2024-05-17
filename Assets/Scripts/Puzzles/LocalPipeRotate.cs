using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR.Interaction.Toolkit.AR;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocalPipeRotate : MonoBehaviour
{
    
    ActionBasedController controller_L;
    ActionBasedController controller_R;
    static int rotated = 0;

    [SerializeField] AudioSource rot;

    [SerializeField] PipeRotate rotator;

    bool InTrig;

    ActionBasedController[] controllers;

    private void Update()
    {
        InTrig=rotator.InTrig;
    }


    private void Start()
    {
        controllers = FindObjectsOfType<ActionBasedController>();
        if (controllers[0].tag == "Right")
        {
            controller_R = controllers[0];
            controller_L = controllers[1];
        }
        else
        {
            controller_L = controllers[0];
            controller_R = controllers[1];
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (InTrig)
        {
            if ((other.tag == "Left" && controller_L.selectAction.action.ReadValue<float>() == 1 || other.tag == "Right" && controller_R.selectAction.action.ReadValue<float>() == 1))
            {
                // Debug.Log("PIPE");
                if (rotated == 0)
                {

                    this.gameObject.transform.localEulerAngles += new Vector3(0, 0, 90);
                    rotated = 1;
                    rot.Play();

                }
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (controller_L.selectAction.action.ReadValue<float>() == 0 && controller_R.selectAction.action.ReadValue<float>() == 0)
            rotated = 0;        
    }


}
