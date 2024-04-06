using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;

public class ForAnimation : MonoBehaviour
{
   
   //[SerializeField] private Animator _animator_r;
   public GameObject Right;
   public GameObject Left;
   public bool Grabbed_R()
   {
      if (gameObject.GetNamedChild("[Right Controller] Dynamic Attach"))
         return true;
      return false;
   }
   public bool Grabbed_L()
   {
      if (gameObject.GetNamedChild("[Left Controller] Dynamic Attach"))
         return true;
      return false;
   }

   private void Update()
   {
      if (Grabbed_R())
         Right.SetActive(false);
      else
         Right.SetActive(true);
      
      if (Grabbed_L())
         Left.SetActive(false);
      else
         Left.SetActive(true);
      
      
   }
}
