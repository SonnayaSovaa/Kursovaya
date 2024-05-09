using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DropDown : MonoBehaviour
{

    public TMP_Dropdown drdw;
    [SerializeField] TMP_Text opisanie;

    private void Start()
    {
        opisanie.text = opisanie.text = "—лабые и медленные враги, много лечени€, меньша€ цель.";
        SetInt("LevelDif", 0);
    }
    public void ValChange()
    {
        switch (drdw.value)
        {
            case 0:
                opisanie.text = "—лабые и медленные враги, много лечени€, меньша€ цель.";
                SetInt("LevelDif", 0);
                break;

            case 1:
                opisanie.text = " репкие и уверенные враги, достаточное количество лечени€, нормальна€ цель.";
                SetInt("LevelDif", 1);
                break;

            case 2:
                opisanie.text = "—ильные и быстрые враги, мало лечени€, больша€ цель.";
                SetInt("LevelDif", 2);
                break;

        }
    }

    public void SetInt(string KeyName, int Value)
    {
        PlayerPrefs.SetInt(KeyName, Value);
    }
}
