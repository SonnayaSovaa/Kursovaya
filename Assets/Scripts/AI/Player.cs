using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int currhealth = 100;

    [SerializeField] TMP_Text timer;

    [SerializeField] private Slider healthSl;

    float time = 0;

    public int score;

    private void Update()
    {
        if (currhealth>0)
            time += Time.deltaTime;

        timer.text = $"{Convert.ToInt32(time / 3600)}:{Convert.ToInt32(Math.Floor(time % 3600 / 60))}:{Convert.ToInt32(time % 60)}";
    }

    private void Start()
    {
        currhealth = PlayerPrefs.GetInt("Health");
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


    public void SetInt(string KeyName, int Value)
    {
        PlayerPrefs.SetInt(KeyName, Value);
    }

    public void SetFloat(string KeyName, float Value)
    {
        PlayerPrefs.SetFloat(KeyName, Value);
    }
}
