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

    public bool activate=false;

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

    float turn;
    float move;



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

        move = igrok.GetComponent<ActionBasedContinuousMoveProvider>().moveSpeed;
        turn = igrok.GetComponent<ActionBasedSnapTurnProvider>().turnAmount;
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

        igrok.GetComponent<ActionBasedContinuousMoveProvider>().moveSpeed = move;
        igrok.GetComponent<ActionBasedSnapTurnProvider>().turnAmount = turn;

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


        igrok.GetComponent<ActionBasedContinuousMoveProvider>().moveSpeed = 0f;
        igrok.GetComponent<ActionBasedSnapTurnProvider>().turnAmount = 0f;

        activate = true;        

    }

    public void ToMenu()
    {
        Time.timeScale = 1f;
        pause.SetActive(false);
        playerAudio.PlayOneShot(click);
        loading.SetActive(true);
        SceneManager.LoadSceneAsync("Menu");
    }
}

