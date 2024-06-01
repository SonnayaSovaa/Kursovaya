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

    string currScene;

    Transform movingpoint;



    private void Start()
    {



        weapon = FindObjectOfType<Weap_Desc>();

        currScene = SceneManager.GetActiveScene().name;

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

    private void Update()
    {
        inHand = weapon.weap;
    }

    public void OnTriggerStay(Collider other)
    {
        Debug.Log("Door1");
        if (other.tag == "Left" && controller_L.selectAction.action.ReadValue<float>() >0 || other.tag == "Right" && controller_R.selectAction.action.ReadValue<float>() >0)
        {
                       
            Debug.Log("Door");


            switch (currScene)
            {

                case "Steam_Lab":
                    golov = PlayerPrefs.GetInt("PipeRotat");
                    

                    if (golov==1 && inHand)
                        DoorOpen(this.name);
                    break;


                case "Forest":
                    golov = PlayerPrefs.GetInt("MagicCube");
                    
                    if (golov == 1 && inHand)
                        DoorOpen(this.name);
                    break;


                case "Start":
                    
                    if (this.name == "ToSteam")
                    {
                        golov = PlayerPrefs.GetInt("PipeRotat");
                        if (golov == 0 && inHand)
                            DoorOpen(this.name);
                    }
                    else if (this.name == "ToLes")
                    {
                        golov = PlayerPrefs.GetInt("MagicCube");
                        if (golov == 0 && inHand)
                            DoorOpen(this.name);
                    }

                    else if (this.name == "Arena")
                    {
                        golov = PlayerPrefs.GetInt("MagicCube") + PlayerPrefs.GetInt("PipeRotat");
                        if (golov == 2 && inHand)
                            DoorOpen(this.name);
                    }

                    break;
            }
        }

    }

    void DoorOpen(string name)
    {
        if (name=="Steam_Lab" || name=="Forest") door.transform.Translate(Vector3.left * 2 * Time.deltaTime);
        else door.transform.Translate(Vector3.right * 2 * Time.deltaTime);

        
    }

}
