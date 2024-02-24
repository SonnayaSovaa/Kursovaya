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
    }
    public void ValChange()
    {
        switch(drdw.value)
        {
            case 0:
                opisanie.text = "—лабые и медленные враги, много лечени€, меньша€ цель.";
                break;

            case 1:
                opisanie.text = " репкие и уверенные враги, достаточное количество лечени€, нормальна€ цель.";
                break;

            case 2:
                opisanie.text = "—ильные и быстрые враги, мало лечени€, больша€ цель.";
                break;

        }
    }
}
