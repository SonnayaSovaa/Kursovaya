using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicVolume : MonoBehaviour
{
    [SerializeField] AudioSource[] mus;

    private void Awake()
    {
        float k= PlayerPrefs.GetFloat("SoundValue");
        foreach (AudioSource source in mus)
        {
            source.volume = source.volume * k;
        }
    }
}
