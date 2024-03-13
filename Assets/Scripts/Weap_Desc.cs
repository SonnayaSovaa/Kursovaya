using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.XR.CoreUtils;
using Unity.VisualScripting;
//using Unity.XR.Oculus;
//using Unity.XR.Oculus.Input;

public class Weap_Desc : MonoBehaviour
{
    [SerializeField] TMP_Text description;
    [SerializeField] TMP_Text rank;
    [SerializeField] TMP_Text uron;

    public static int real_uron;

    public GameObject[] weapons;
    public void InHand()
    {
        foreach (var i in weapons)
        {
            if (i.GetNamedChild("[Right Controller] Dynamic Attach") || i.GetNamedChild("[Left Controller] Dynamic Attach"))
            {
                What(int.Parse(i.tag));
                break;

            }
        }



        void What(int cur_tag)
        {

            switch (cur_tag)
            {
                case 0:
                    description.text = "Описание: Ноль вообще";
                    rank.text = "Ранг: 1";
                    uron.text = "Урон: 20";
                    real_uron = 20;
                    break;
                case 1:
                    description.text = "Описание: Адын";
                    rank.text = "Ранг: 2";
                    uron.text = "Урон: 666";
                    real_uron = 666;
                    break;
                case 2:
                    description.text = "Описание: ДВААААА";
                    rank.text = "Ранг: 6";
                    uron.text = "Урон: 12398";
                    real_uron = 12398;
                    break;
            }

            SetInt("Uron", real_uron);
        }

    }

    public void OutHand()
    {
        description.text = "Описание: твои руки лол";
        rank.text = "Ранг: 0";
        uron.text = "Урон: какой урон? у тебя лапки";
        real_uron = 0;
    }


    public void SetInt(string KeyName, int Value)
    {
        PlayerPrefs.SetInt(KeyName, Value);
    }

}
