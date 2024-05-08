using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorFromLab : MonoBehaviour
{

    int golov;
    public static bool inHand = false;

    [SerializeField] GameObject door;

    private void OnTriggerStay(Collider other)
    {
        string currScene = SceneManager.GetActiveScene().name;

        Vector3 newpos = new Vector3(0, 0, 0);

        switch (currScene)
        {          

            case "SteamLab":
                golov= PlayerPrefs.GetInt("PipeRotat");
                newpos = new Vector3(0, 0, 1f);
                if (golov==1 && inHand)
                    DoorOpen(newpos);
                break;


            case "מעק¸ע":
                golov= PlayerPrefs.GetInt("MagicCube");
                newpos = new Vector3(0, 0, 1f);
                if (golov == 1 && inHand)
                    DoorOpen(newpos);
                break;


            case "Start":
                newpos = new Vector3(0, 0, 1f);
                if (other.name == "ToSteam")
                {
                    golov = PlayerPrefs.GetInt("PipeRotat");
                    if (golov == 0 && inHand)
                        DoorOpen(newpos);
                }
                else if (other.name == "ToLes")
                {
                    golov = PlayerPrefs.GetInt("MagicCube");
                    if (golov == 0 && inHand)
                        DoorOpen(newpos);
                }

                else if (other.name=="Arena")
                {
                    golov = PlayerPrefs.GetInt("MagicCube") + PlayerPrefs.GetInt("PipeRotat");
                    if (golov == 2 && inHand)
                        DoorOpen(newpos);
                }

                break;


            case "Arena":
                newpos = new Vector3(0, 0, 1f);
                golov = PlayerPrefs.GetInt("Boss_Dead");
                if (golov == 1)
                    DoorOpen(newpos);
                break;
        }


        
    }

    void DoorOpen(Vector3 newpos)
    {
        for (int i=0; i<100000; i++)
        {
            door.transform.position += newpos;
        }
    }

}
