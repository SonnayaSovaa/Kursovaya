using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.XR.CoreUtils;
//using Unity.XR.Oculus;
//using Unity.XR.Oculus.Input;
using UnityEngine.XR.Interaction.Toolkit;

public class Weap_Desc : MonoBehaviour
{
    [SerializeField] TMP_Text description;
    [SerializeField] TMP_Text rank;
    [SerializeField] TMP_Text uron;

    int real_uron;

    public GameObject[] weapons;
   

    public static bool weap=false;

    
    public void InHand()
    {
        for (int i=0; i<weapons.Length; i++) 
        {
            if (weapons[i].GetNamedChild("[Right Controller] Dynamic Attach") || weapons[i].GetNamedChild("[Left Controller] Dynamic Attach"))
            {
                weap=true;
                What(int.Parse(weapons[i].tag));

                for (int j=0; j<weapons.Length; j++)
                {
                    if (i!=j)
                        (weapons[j].GetComponent("XRGrabInteractable") as MonoBehaviour).enabled = false;
                }
                
                break;

            }
        }



        void What(int cur_tag)
        {

            switch (cur_tag)
            {
                case 0:
                    description.text = "Описание: Довольно обычная, но корепкая булава.";
                    rank.text = "Ранг: 1";
                    uron.text = "Урон: 30";
                    real_uron = 30;
                    break;
                case 1:
                    description.text = "Описание: ";
                    rank.text = "Ранг: ";
                    uron.text = "Урон: ";
                    real_uron = 6;
                    break;
                case 2:
                    description.text = "Описание: ";
                    rank.text = "Ранг: ";
                    uron.text = "Урон: ";
                    real_uron = 6;
                    break;
                case 3:
                    description.text = "Описание: ";
                    rank.text = "Ранг: ";
                    uron.text = "Урон: ";
                    real_uron = 6;
                    break;
                case 4:
                    description.text = "Описание: ";
                    rank.text = "Ранг: ";
                    uron.text = "Урон: ";
                    real_uron = 6;
                    break;
                case 5:
                    description.text = "Описание: ";
                    rank.text = "Ранг: ";
                    uron.text = "Урон: ";
                    real_uron = 6;
                    break;
                case 6:
                    description.text = "Описание: ";
                    rank.text = "Ранг: ";
                    uron.text = "Урон: ";
                    real_uron = 6;
                    break;
                case 7:
                    description.text = "Описание: ";
                    rank.text = "Ранг: ";
                    uron.text = "Урон: ";
                    real_uron = 6;
                    break;
                case 8:
                    description.text = "Описание: ";
                    rank.text = "Ранг: ";
                    uron.text = "Урон: ";
                    real_uron = 6;
                    break;
                case 9:
                    description.text = "Описание: ";
                    rank.text = "Ранг: ";
                    uron.text = "Урон: ";
                    real_uron = 6;
                    break;
                case 10:
                    description.text = "Описание: ";
                    rank.text = "Ранг: ";
                    uron.text = "Урон: ";
                    real_uron = 6;
                    break;
                case 11:
                    description.text = "Описание: ";
                    rank.text = "Ранг: ";
                    uron.text = "Урон: ";
                    real_uron = 6;
                    break;
                case 12:
                    description.text = "Описание: ";
                    rank.text = "Ранг: ";
                    uron.text = "Урон: ";
                    real_uron = 6;
                    break;
                case 13:
                    description.text = "Описание: ";
                    rank.text = "Ранг: ";
                    uron.text = "Урон: ";
                    real_uron = 6;
                    break;
                case 14:
                    description.text = "Описание: ";
                    rank.text = "Ранг: ";
                    uron.text = "Урон: ";
                    real_uron = 6;
                    break;
                case 15:
                    description.text = "Описание: ";
                    rank.text = "Ранг: ";
                    uron.text = "Урон: ";
                    real_uron = 6;
                    break;
                case 16:
                    description.text = "Описание: ";
                    rank.text = "Ранг: ";
                    uron.text = "Урон: ";
                    real_uron = 6;
                    break;
                case 17:
                    description.text = "Описание: ";
                    rank.text = "Ранг: ";
                    uron.text = "Урон: ";
                    real_uron = 6;
                    break;
                case 18:
                    description.text = "Описание: ";
                    rank.text = "Ранг: ";
                    uron.text = "Урон: ";
                    real_uron = 6;
                    break;
                case 19:
                    description.text = "Описание: ";
                    rank.text = "Ранг: ";
                    uron.text = "Урон: ";
                    real_uron = 6;
                    break;
                case 21:
                    description.text = "Описание: ";
                    rank.text = "Ранг: ";
                    uron.text = "Урон: ";
                    real_uron = 6;
                    break;
                case 22:
                    description.text = "Описание: ";
                    rank.text = "Ранг: ";
                    uron.text = "Урон: ";
                    real_uron = 6;
                    break;
                case 23:
                    description.text = "Описание: ";
                    rank.text = "Ранг: ";
                    uron.text = "Урон: ";
                    real_uron = 6;
                    break;
                case 24:
                    description.text = "Описание: ";
                    rank.text = "Ранг: ";
                    uron.text = "Урон: ";
                    real_uron = 6;
                    break;
                case 25:
                    description.text = "Описание: ";
                    rank.text = "Ранг: ";
                    uron.text = "Урон: ";
                    real_uron = 6;
                    break;
                case 26:
                    description.text = "Описание: ";
                    rank.text = "Ранг: ";
                    uron.text = "Урон: ";
                    real_uron = 6;
                    break;
                case 27:
                    description.text = "Описание: ";
                    rank.text = "Ранг: ";
                    uron.text = "Урон: ";
                    real_uron = 6;
                    break;
                case 28:
                    description.text = "Описание: ";
                    rank.text = "Ранг: ";
                    uron.text = "Урон: ";
                    real_uron = 6;
                    break;
                case 29:
                    description.text = "Описание: ";
                    rank.text = "Ранг: ";
                    uron.text = "Урон: ";
                    real_uron = 6;
                    break;
                case 30:
                    description.text = "Описание: ";
                    rank.text = "Ранг: ";
                    uron.text = "Урон: ";
                    real_uron = 6;
                    break;
                case 31:
                    description.text = "Описание: ";
                    rank.text = "Ранг: ";
                    uron.text = "Урон: ";
                    real_uron = 6;
                    break;
                case 32:
                    description.text = "Описание: ";
                    rank.text = "Ранг: ";
                    uron.text = "Урон: ";
                    real_uron = 6;
                    break;
                case 33:
                    description.text = "Описание: ";
                    rank.text = "Ранг: ";
                    uron.text = "Урон: ";
                    real_uron = 6;
                    break;
                case 34:
                    description.text = "Описание: ";
                    rank.text = "Ранг: ";
                    uron.text = "Урон: ";
                    real_uron = 6;
                    break;
                case 35:
                    description.text = "Описание: ";
                    rank.text = "Ранг: ";
                    uron.text = "Урон: ";
                    real_uron = 6;
                    break;
                case 36:
                    description.text = "Описание: ";
                    rank.text = "Ранг: ";
                    uron.text = "Урон: ";
                    real_uron = 6;
                    break;
            }

            SetInt("Uron", real_uron);
        }

    }

    public void OutHand()
    {
        description.text = "Описание: Что ж, это ваши руки.";
        rank.text = "Ранг: 0";
        uron.text = "Урон: 0";
        real_uron = 0;

        weap = false;

        foreach (var j in weapons)
        {
            (j.GetComponent("XRGrabInteractable") as MonoBehaviour).enabled = true;
        }
    } 


    public void SetInt(string KeyName, int Value)
    {
        PlayerPrefs.SetInt(KeyName, Value);
    }

}
