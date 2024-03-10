using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicVolume : MonoBehaviour
{
    [SerializeField] AudioSource mus;

    private void Awake()
    {
        mus.volume = PlayerPrefs.GetFloat("SoundValue");
    }
}
