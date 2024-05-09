using System.Collections;
using TMPro.Examples;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToLab : MonoBehaviour
{
    public static bool inHand = false;

    string m_Scene;

    public GameObject Igrok;


    public void Update()
    {
        inHand = Weap_Desc.weap;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            string currScene = SceneManager.GetActiveScene().name;

            if (this.name == "ToSteam")
            {
                int prohodSteam = PlayerPrefs.GetInt("PipeRotat");

                if (prohodSteam == 0 && inHand)
                {
                    m_Scene = "Steam_Lab";
                    //StartCoroutine(LoadYourAsyncScene());
                }
            }

            else if (this.name == "ToLes")
            {
                int prohodForest = PlayerPrefs.GetInt("MagicCube");

                if (prohodForest == 0 && inHand)
                {
                    m_Scene = "Forest";
                    //StartCoroutine(LoadYourAsyncScene());
                }
            }

            else if (this.name == "ToEnd")
            {
                int dead = PlayerPrefs.GetInt("Boss_Dead");

                if (dead == 1)
                {
                    m_Scene = "End";
                    //StartCoroutine(LoadYourAsyncScene());
                }
            }

            else if (this.name == "ToFin")
            {
                int prohodForest = PlayerPrefs.GetInt("MagicCube");
                int prohodSteam = PlayerPrefs.GetInt("PipeRotat");

                if (prohodForest == 1 && prohodSteam == 1 && inHand)
                {
                    m_Scene = "Arena";
                    //StartCoroutine(LoadYourAsyncScene());
                }
            }

            else if (this.name == "ToStart")
            {
                Debug.Log("EE");
                m_Scene = "Start";
                if (currScene == "Steam_Lab")
                {
                    int prohodSteam = PlayerPrefs.GetInt("PipeRotat");

                    if (true)//(prohodSteam == 1 && inHand)
                    {
                        //Load(m_Scene);
                        StartCoroutine(LoadYourAsyncScene());
                    }
                }
                else if (currScene == "Forest")
                {
                    int prohodForest = PlayerPrefs.GetInt("MagicCube");

                    if (prohodForest == 1 && inHand)
                    {
                        Load(m_Scene);
                        //StartCoroutine(LoadYourAsyncScene());
                    }
                }

            }
        }

        void Load(string Sc_name)
        {
            SceneManager.LoadScene(Sc_name);
        }

        
        IEnumerator LoadYourAsyncScene()
        {
            // Set the current Scene to be able to unload it later
            Scene currentScene = SceneManager.GetActiveScene();

            // The Application loads the Scene in the background at the same time as the current Scene.
            SceneManager.MoveGameObjectToScene(Igrok, SceneManager.GetSceneByName("Start"));

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(m_Scene, LoadSceneMode.Additive);

            // Wait until the last operation fully loads to return anything
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }
        
    }

}
