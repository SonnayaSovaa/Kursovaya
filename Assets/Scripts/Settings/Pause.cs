using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Loading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject pause;
    [SerializeField] GameObject igrok;

    static bool activate=false;

    [SerializeField] public AudioSource playerAudio;
    [SerializeField] AudioClip click;

    private Controls controls;

    [SerializeField] Player player;
    [SerializeField] Weap_Desc weap;

    [SerializeField] Slider slider;
    [SerializeField] public TMP_Text description;
    [SerializeField] public TMP_Text rank;
    [SerializeField] public TMP_Text uron;
    [SerializeField] public TMP_Text timer;
    [SerializeField] public TMP_Text Score;

    [SerializeField] GameObject loading;



    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }


    private void Awake()
    {
        controls = new Controls();
        controls.pause.Pause.started += ctx => MakePause();
    }


    public void MakePause()
    {
        if (activate) Play();
        else Stop();
    }



    public void Play()
    {
        Time.timeScale = 1f;

        playerAudio.PlayOneShot(click);

        pause.SetActive(false);

        (igrok.GetComponent<ActionBasedContinuousMoveProvider>() as MonoBehaviour).enabled = true;
        (igrok.GetComponent<ActionBasedContinuousTurnProvider>() as MonoBehaviour).enabled = true;

        igrok.GetComponent<Collider>().enabled = true;
        igrok.GetComponent<Collider>().enabled = true;

        

        activate = false;

    }


    void Stop()
    {
        Time.timeScale = 0f;

        slider.value = player.healthSl.value;
        description.text = weap.description.text;
        Score.text = player.Score.text;
        timer.text = player.timer.text;
        uron.text = weap.uron.text;
        rank.text = weap.rank.text;

        playerAudio.PlayOneShot(click);

        pause.SetActive(true);
        (igrok.GetComponent<ActionBasedContinuousMoveProvider>() as MonoBehaviour).enabled = false;
        (igrok.GetComponent<ActionBasedContinuousTurnProvider>() as MonoBehaviour).enabled = false;

        igrok.GetComponent<Collider>().enabled = false;
        igrok.GetComponent<Collider>().enabled = false;
        

        activate = true;        

    }

    public void ToMenu()
    {
        playerAudio.PlayOneShot(click);
        loading.SetActive(true);
        SceneManager.LoadSceneAsync(0);
    }
}

