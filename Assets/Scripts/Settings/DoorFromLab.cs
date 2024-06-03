using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using System.Data;

public class DoorFromLab : MonoBehaviour
{
    public ActionBasedController controller_L;
    public ActionBasedController controller_R;

    ActionBasedController[] controllers;

    int golov;
    public bool inHand;

    [SerializeField] GameObject door;

    Weap_Desc weapon;


    private void Start()
    {
        weapon = FindObjectOfType<Weap_Desc>();

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

        int mc = PlayerPrefs.GetInt("MagicCube");
        int pp = PlayerPrefs.GetInt("PipeRotat");

        if (this.name=="ToLes" && mc==1)
            Destroy(this);
        if (this.name=="ToStaem" && pp==1) Destroy(this);
    } 

    private void Update()
    {
        inHand = weapon.weap;
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Left" && controller_L.selectAction.action.ReadValue<float>() > 0 || other.tag == "Right" && controller_R.selectAction.action.ReadValue<float>() > 0)
        {
            DoorOpen();
        }

    }

    void DoorOpen()
    {
        if (inHand) door.transform.Translate(Vector3.right * 2 * Time.deltaTime);

        
    }

}
