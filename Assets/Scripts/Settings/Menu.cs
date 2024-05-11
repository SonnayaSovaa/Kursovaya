using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject menu_nastroek;
    public AudioClip AudioClip;
    [SerializeField]  AudioSource audioSource;


    public void Igrat()
    {
        audioSource.PlayOneShot(AudioClip);

        SetInt("MagicCube", 0);
        SetInt("PipeRotat", 0);
        SetInt("Boss_Dead", 0);
        SetInt("Enemy_Dead", 0);
        SetInt("Score", 0);
        SetInt("Health", 100);

        SetFloat("Time", 0);

        SceneManager.LoadScene("Start");

    }


    public void Vihod()
    {
        audioSource.PlayOneShot(AudioClip);
        Application.Quit();
        
    }


    public void nastroyki()
    {
        menu_nastroek.SetActive(true);
        audioSource.PlayOneShot(AudioClip);
    }



    public void SetInt(string KeyName, int Value)
    {
        PlayerPrefs.SetInt(KeyName, Value);
    }

    public void SetFloat(string KeyName, float Value)
    {
        PlayerPrefs.SetFloat(KeyName, Value);
    }
}
