using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject menu_nastroek;
    bool vkl=false;
    public AudioClip AudioClip;
    [SerializeField]  AudioSource audioSource;

    public void Igrat()
    {
        audioSource.PlayOneShot(AudioClip);
        SceneManager.LoadScene("MainScene");
        
    }


    public void Vihod()
    {
        audioSource.PlayOneShot(AudioClip);
        Application.Quit();
        
    }


    public void nastroyki()
    {
        vkl = !vkl;
        menu_nastroek.SetActive(vkl);
        audioSource.PlayOneShot(AudioClip);
    }


}
