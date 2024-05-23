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

    private void Awake()
    {
        mus = FindObjectsOfType<AudioSource>();

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
