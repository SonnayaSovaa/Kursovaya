using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] public GameObject loading;

    [SerializeField] private Image health1;
    [SerializeField] private Image health2;
    [SerializeField] private Image health3;
    [SerializeField] private Image health4;


    public int currhealth = 100;

    [SerializeField] public  TMP_Text timer;
    [SerializeField] public TMP_Text Score;

    [SerializeField] public Slider healthSl;

    float time = 0;

    public int score;

    public bool Shag;
    [SerializeField] public AudioSource playerAudio;

    [SerializeField] AudioClip Uron;
    [SerializeField] AudioClip Steam;
    [SerializeField] AudioClip Forest;

    [SerializeField] public GameObject igrok;

    private Controls controls;



    private void Awake()
    {
        controls = new Controls();
        controls.control.MoveAudio.performed += ctx => MovingAudio();

    }


    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }


    public void MovingAudio()
    {
        if (Shag)
        {
            if (SceneManager.GetActiveScene().name == "Steam_Lab")
            {
                playerAudio.clip=Steam;
                playerAudio.Play();
            }
            else
            {
                playerAudio.clip = Forest;
                playerAudio.Play();
            }

        }
    }

    private void Update()
    {
        if (currhealth>0)
            time += Time.deltaTime;

        timer.text = $"{Convert.ToInt32(time / 3600)}:{Convert.ToInt32(Math.Floor(time % 3600 / 60))}:{Convert.ToInt32(time % 60)}";
               
    }

    private void Start()
    {
        //currhealth = PlayerPrefs.GetInt("Health");
        currhealth = 100;
        healthSl.value = currhealth;
        loading.SetActive(false);

    }

    public void GetDamage(int uron)
    {
        playerAudio.PlayOneShot(Uron);
        if (currhealth - uron <= 0)
        {
            currhealth = 0;
            Death();
        }

        else currhealth -= uron;

        healthSl.value = currhealth;

        health1.color = new Color(1, 1, 1, 1 - currhealth / 100);
        health2.color = new Color(1, 1, 1, 1 - currhealth / 100);
        health3.color = new Color(1, 1, 1, 1 - currhealth / 100);
        health4.color = new Color(1, 1, 1, 1 - currhealth / 100);

    }

    public void MoveAudio(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            playerAudio.PlayOneShot(Uron);
        }
    }

    void Death()
    {
        SetInt("Score", score);
        SetInt("Health", 0);
        SetFloat("Time", time);

        loading.SetActive(true);
        
        SceneManager.LoadSceneAsync("End");
        //Destroy(igrok);
    }


    public void ScoreUp(int up)
    {
        score += up;
        Score.text = "" + score;
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
