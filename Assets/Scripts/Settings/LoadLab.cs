using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToLab : MonoBehaviour
{
    public static bool inHand = false;

    string m_Scene;

    [SerializeField] private GameObject Igrok;

    Weap_Desc weapon;

    private void Start()
    {
        weapon = FindObjectOfType<Weap_Desc>();
    }

    public void Update()
    {
        inHand = weapon.weap;
    }

    private void OnTriggerStay(Collider other)
    {
        DontDestroyOnLoad(Igrok);
        if (other.tag == "Player")
        {
            string currScene = SceneManager.GetActiveScene().name;

            if (this.name == "ToSteam")
            {
                int prohodSteam = PlayerPrefs.GetInt("PipeRotat");

                if (prohodSteam == 0 && inHand)
                {
                    m_Scene = "Steam_Lab";
                }
            }

            else if (this.name == "ToLes")
            {
                int prohodForest = PlayerPrefs.GetInt("MagicCube");

                if (prohodForest == 0 && inHand)
                {
                    m_Scene = "Forest";
                }
            }

            else if (this.name == "ToEnd")
            {
                int dead = PlayerPrefs.GetInt("Boss_Dead");

                if (dead == 1)
                {
                    m_Scene = "End";
                }
            }

            else if (this.name == "ToFin")
            {
                int prohodForest = PlayerPrefs.GetInt("MagicCube");
                int prohodSteam = PlayerPrefs.GetInt("PipeRotat");

                if (prohodForest == 1 && prohodSteam == 1 && inHand)
                {
                    m_Scene = "Arena";
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
                        Load(m_Scene);
                    }
                }
                else if (currScene == "Forest")
                {
                    int prohodForest = PlayerPrefs.GetInt("MagicCube");

                    if (prohodForest == 1 && inHand)
                    {
                        Load(m_Scene);
                    }
                }

            }
        }

        void Load(string Sc_name)
        {
            SceneManager.LoadScene(Sc_name);
        }


        
    }

}
