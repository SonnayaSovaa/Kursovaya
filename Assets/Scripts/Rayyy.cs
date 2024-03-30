using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.OpenVR;
using UnityEngine.XR.OpenXR.Features.Interactions;
using Unity.XR.Oculus.Input;
using UnityEngine.XR.Interaction.Toolkit;

public class Rayyy : MonoBehaviour
{
   private void Update()
   {
      //
   }

   public void OnTriggerEnter(Collider other)
   {
      Debug.Log(other.tag);
   }
}
