using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicVolume : MonoBehaviour
{
    AudioSource[] mus;

    [SerializeField] GameObject heal;

    Player player;

    public TheWeapon[] weapons;

    public GameObject[] real_weapons;

    string currSc;

    [SerializeField] GameObject StartIgrok;

    [SerializeField] GameObject source;

    private void Awake()
    {
        float k = PlayerPrefs.GetFloat("SoundValue");

        int mc = PlayerPrefs.GetInt("MagicCube");
        int pp = PlayerPrefs.GetInt("PipeRotat");
        currSc = SceneManager.GetActiveScene().name;

        if (currSc != "TheEnd"|| currSc != "Menu")
        {

            weapons = FindObjectsOfType<TheWeapon>();

            real_weapons = new GameObject[weapons.Length];

            for (int i = 0; i < weapons.Length; i++)
            {
                real_weapons[i] = weapons[i].gameObject;
            }

            player = FindObjectOfType<Player>();
            mus = FindObjectsOfType<AudioSource>();

            player.loading.SetActive(false);
        }




        if (currSc != "Start")
        {
            foreach (AudioSource source in mus)
            {
                source.volume = source.volume * k;
            }
        }

        else
        {
            if (StartIgrok != null && (pp == 1 || mc == 1))
            {
                source.SetActive(true);
                Destroy(StartIgrok);
            }
        }

        

        if (currSc!="Start" && mc==1 && pp==1)
        {
            heal.SetActive(true);
        }
    }
}
