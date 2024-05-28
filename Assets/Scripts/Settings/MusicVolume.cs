using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicVolume : MonoBehaviour
{
    AudioSource[] mus;

    public bool start;

    [SerializeField] GameObject heal;

    Player player;

    TheWeapon[] weapons;

    public GameObject[] real_weapons;

    private void Awake()
    {
        weapons = FindObjectsOfType<TheWeapon>();

        real_weapons= new GameObject[weapons.Length];

        for (int i=0; i<weapons.Length; i++)
        {
            real_weapons[i] = weapons[i].gameObject;
        }

        player=FindObjectOfType<Player>();
        mus = FindObjectsOfType<AudioSource>();

        player.loading.SetActive(false);

        float k= PlayerPrefs.GetFloat("SoundValue");

        if (SceneManager.GetActiveScene().name != "Start")
        {
            foreach (AudioSource source in mus)
            {
                source.volume = source.volume * k;
            }
        }

        int mc = PlayerPrefs.GetInt("MagicCube");
        int pp = PlayerPrefs.GetInt("PipeRotat");

        if (start && mc==1 && pp==1)
        {
            heal.SetActive(true);
        }
    }
}
