using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

//public class TheWeapon : MonoBehaviour { }


public class TheWeapon : XRGrabInteractable
{

    [SerializeField] GameObject attach;

    ActionBasedController[] controllers;
    public ActionBasedController controller_L;
    public ActionBasedController controller_R;


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


    public virtual void AttachCustomReticle(XRBaseInteractor interactor) => AttachCustomReticle(interactor as IXRInteractor);

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        SetParentToXRRig();
        base.OnSelectEntered(args);       

    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        //if (args.interactor.tag== "Right" && controller_R.selectAction.action.ReadValue<float>() == 0 || args.interactor.tag == "Left" && controller_L.selectAction.action.ReadValue<float>() == 0)
        SetParentToWorld();
        base.OnSelectExited(args);
    }

    public void SetParentToXRRig()
    {
        transform.SetParent(selectingInteractor.transform);
    }

    public void SetParentToWorld()
    {
        transform.SetParent(null);
    }
}
