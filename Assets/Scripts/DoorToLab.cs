using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLab : MonoBehaviour
{
    public static bool inHand = false;

    string m_Scene;

    public GameObject Igrok;



    private void OnTriggerStay(Collider other)
    {

        if (this.name == "ToSteam")
        {
            int prohodSteam = PlayerPrefs.GetInt("PipeRotat");

            if (prohodSteam ==0 && inHand)
            {
                m_Scene = "Steam_Lab";
                StartCoroutine(LoadYourAsyncScene());
            }
        }

       else if (this.name == "ToLes")
        {
            int prohodForest = PlayerPrefs.GetInt("MagicCube");

            if (prohodForest == 0 && inHand)
            {
                m_Scene = "отчёт";
                StartCoroutine(LoadYourAsyncScene());
            }
        }


        else if (this.name == "ToFin")
        {
            int prohodForest = PlayerPrefs.GetInt("MagicCube");
            int prohodSteam = PlayerPrefs.GetInt("PipeRotat");

            if (prohodForest == 1 && prohodSteam==1 && inHand)
            {
                m_Scene = "Arena";
                StartCoroutine(LoadYourAsyncScene());
            }
        }

    }

    IEnumerator LoadYourAsyncScene()
    {
        // Set the current Scene to be able to unload it later
        Scene currentScene = SceneManager.GetActiveScene();

        // The Application loads the Scene in the background at the same time as the current Scene.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(m_Scene, LoadSceneMode.Additive);

        // Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }


}
