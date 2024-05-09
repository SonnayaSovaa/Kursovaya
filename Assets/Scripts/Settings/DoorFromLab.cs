using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorFromLab : MonoBehaviour
{
    public ActionBasedController controller_L;
    public ActionBasedController controller_R;

    int golov;
    public static bool inHand = false;

    [SerializeField] GameObject door;
    //[SerializeField] int X;
    //[SerializeField] int Y;
    //[SerializeField] int Z;

    public void OnTriggerStay(Collider other)
    {
        Debug.Log("Door1");
        if ((other.tag == "Left" && controller_L.selectAction.action.ReadValue<float>() == 1 || other.tag == "Right" && controller_R.selectAction.action.ReadValue<float>() == 1))
        {
            inHand = Weap_Desc.weap;

            string currScene = SceneManager.GetActiveScene().name;

            Debug.Log("Door");


            switch (currScene)
            {

                case "Steam_Lab":
                    golov = PlayerPrefs.GetInt("PipeRotat");
                    

                    if (golov==1 && inHand)
                        DoorOpen();
                    break;


                case "Forest":
                    golov = PlayerPrefs.GetInt("MagicCube");
                    
                    if (golov == 1 && inHand)
                        DoorOpen();
                    break;


                case "Start":
                    
                    if (this.name == "ToSteam")
                    {
                        golov = PlayerPrefs.GetInt("PipeRotat");
                        if (golov == 0 && inHand)
                            DoorOpen();
                    }
                    else if (this.name == "ToLes")
                    {
                        golov = PlayerPrefs.GetInt("MagicCube");
                        if (golov == 0 && inHand)
                            DoorOpen();
                    }

                    else if (this.name == "Arena")
                    {
                        golov = PlayerPrefs.GetInt("MagicCube") + PlayerPrefs.GetInt("PipeRotat");
                        if (golov == 2 && inHand)
                            DoorOpen();
                    }

                    break;

            }
        }

    }

   


    void DoorOpen()
    {
        Debug.Log("Door");

        door.transform.Translate(Vector3.left * 2 * Time.deltaTime);


        //Destroy(door);
    }

}
