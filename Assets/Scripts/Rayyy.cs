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
    public static int hoverTag;

    public XRController rightHand;
    public InputHelpers.Button R_button;

    public XRController leftHand;
    public InputHelpers.Button L_button;


    public void OnTriggerEnter(Collider other)
   {
        if (!(other.tag == "Untagged" || other.tag == "Zanyat" || other.tag == "Svoboden" || other.tag == "MainCamera" || other.tag == "Left" || other.tag == "Right"))
        {
            hoverTag = Convert.ToInt32(other.tag);

            if (hoverTag == 38 && other.isTrigger)
            {
                bool R_pressed;
                rightHand.inputDevice.IsPressed(R_button, out R_pressed);

                bool L_pressed;
                leftHand.inputDevice.IsPressed(L_button, out L_pressed);

                Collider collider = this.GetComponent<Collider>();
                if ((collider.tag == "Left" && L_pressed) || (collider.tag == "Right" && R_pressed))
                {

                    GameObject currObj = other.gameObject;
                    currObj.transform.parent = null;

                    other.isTrigger = false;

                    Rigidbody rigidbody = currObj.GetComponent<Rigidbody>();
                    rigidbody.useGravity = true;

                }
            }
           
        }
    }

 
}
