using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.OpenVR;
using UnityEngine.XR.OpenXR.Features.Interactions;
using Unity.XR.Oculus.Input;

public class Rayyy : MonoBehaviour
{
    [SerializeField] Transform L_orig;
    [SerializeField] Transform R_orig;

    [SerializeField] RaycastHit hit;
    public OculusTouchController a;
    private void Awake()
    {
        //
    }
}
