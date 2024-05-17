using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class Player : MonoBehaviour
{
    public int currhealth = 100;

    [SerializeField] TMP_Text timer;
    [SerializeField] TMP_Text Score;

    [SerializeField] private Slider healthSl;

    float time = 0;

    public int score;

    public ActionBasedController controller_L;

    public bool Shag;
    [SerializeField] public AudioSource playerAudio;
    [SerializeField] AudioClip Steam;
    [SerializeField] AudioClip Forest;

    private void Update()
    {
        if (currhealth>0)
            time += Time.deltaTime;

        timer.text = $"{Convert.ToInt32(time / 3600)}:{Convert.ToInt32(Math.Floor(time % 3600 / 60))}:{Convert.ToInt32(time % 60)}";

        if (Shag && controller_L.positionAction.action.ReadValue<float>()>0)
        {
            if (SceneManager.GetActiveScene().name == "Steam_Lab")
            {
                playerAudio.PlayOneShot(Steam);
            }
            else
            {
                playerAudio.PlayOneShot(Forest);
            }

        }
    }

    private void Start()
    {
        //currhealth = PlayerPrefs.GetInt("Health");
        currhealth = 100;
        healthSl.value = currhealth/100;
    }

    public void GetDamage(int uron)
    {
        if (currhealth - uron <= 0)
        {
            currhealth = 0;
            Death();
        }

        else currhealth -= uron;
        healthSl.value = currhealth / 100;
    }

    void Death()
    {
        SetInt("Score", score);
        SetInt("Health", 0);
        SetFloat("Time", time);
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
