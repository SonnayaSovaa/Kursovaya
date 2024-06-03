using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorToLab : MonoBehaviour
{
    public static bool inHand = false;

    string m_Scene;

    public GameObject Igrok;

    //Weap_Desc weapon;

    GameObject loading;

    private void Awake()
    {
        Player player= FindObjectOfType<Player>();
        Igrok = player.igrok;
        //weapon =FindObjectOfType<Weap_Desc>();
        loading = player.loading;
    }

    public void Update()
    {
        //inHand = weapon.weap;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            DontDestroyOnLoad(Igrok);
            //DontDestroyOnLoad(FindObjectOfType<CurrentWeapon>().gameObject);
            string currScene = SceneManager.GetActiveScene().name;

            if (this.name == "ToSteam")
            {
                int prohodSteam = PlayerPrefs.GetInt("PipeRotat");

                if (prohodSteam == 0)
                {
                    m_Scene = "Steam_Lab";
                    Load(m_Scene);
                }
            }

            else if (this.name == "ToLes")
            {
                int prohodForest = PlayerPrefs.GetInt("MagicCube");

                if (prohodForest == 0)
                {
                    m_Scene = "Forest";
                    Load(m_Scene);
                }
            }

            else if (this.name == "ToEnd")
            {
                int dead = PlayerPrefs.GetInt("Boss_Dead");

                if (dead == 1)
                {
                    m_Scene = "End";
                    Load(m_Scene);
                    Igrok.SetActive(false);
                }
            }

            else if (this.name == "ToFin")
            {
                int prohodForest = PlayerPrefs.GetInt("MagicCube");
                int prohodSteam = PlayerPrefs.GetInt("PipeRotat");

                if (prohodForest == 1 && prohodSteam == 1 && inHand)
                {
                    m_Scene = "Arena";
                    Load(m_Scene);
                }
            }

            else if (this.name == "ToStart")
            {
                Debug.Log("EE");
                m_Scene = "Start";
                if (currScene == "Steam_Lab")
                {
                    int prohodSteam = PlayerPrefs.GetInt("PipeRotat");

                    if (prohodSteam == 1)
                    {
                        Load(m_Scene);
                    }
                }
                else if (currScene == "Forest")
                {
                    int prohodForest = PlayerPrefs.GetInt("MagicCube");

                    if (prohodForest == 1)
                    {
                        Load(m_Scene);
                    }
                }

            }
        }

        void Load(string Sc_name)
        {
            
            loading.SetActive(true);
            SceneManager.LoadSceneAsync(Sc_name);
        }

        

        
    }

}
