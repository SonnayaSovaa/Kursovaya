using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject pause;
    [SerializeField] GameObject igrok;

    static bool activate=false;

    [SerializeField] public AudioSource playerAudio;
    [SerializeField] AudioClip click;

    public void MakePause()
    {
        if (activate) Play();
        else Stop();
    }




    void Play()
    {

        playerAudio.PlayOneShot(click);

        pause.SetActive(false);

        (igrok.GetComponent<ActionBasedContinuousMoveProvider>() as MonoBehaviour).enabled = true;
        (igrok.GetComponent<ActionBasedContinuousTurnProvider>() as MonoBehaviour).enabled = true;

        igrok.GetComponent<Collider>().enabled = true;
        igrok.GetComponent<Collider>().enabled = true;

        Time.timeScale = 1f;

        activate = false;

    }


    void Stop()
    {

        playerAudio.PlayOneShot(click);

        pause.SetActive(true);
        (igrok.GetComponent<ActionBasedContinuousMoveProvider>() as MonoBehaviour).enabled = false;
        (igrok.GetComponent<ActionBasedContinuousTurnProvider>() as MonoBehaviour).enabled = false;

        igrok.GetComponent<Collider>().enabled = false;
        igrok.GetComponent<Collider>().enabled = false;

        Time.timeScale = 0f;

        activate = true;

        Debug.Log("PAAAAAAAAAAAAAAAUSA");

    }
}

