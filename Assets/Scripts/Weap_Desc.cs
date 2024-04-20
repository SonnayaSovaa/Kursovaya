using UnityEngine;
using TMPro;
using Unity.XR.CoreUtils;
using System;

public class Weap_Desc : MonoBehaviour
{
    [SerializeField] TMP_Text description;
    [SerializeField] TMP_Text rank;
    [SerializeField] TMP_Text uron;

    [SerializeField] TMP_Text timer;

    float tim=0;
    int real_uron;

    public GameObject[] weapons;
   

    public static bool weap=false;

    public void Update()
    {
        tim += Time.deltaTime;
        
        timer.text = $"{Convert.ToInt32(tim/3600)}:{Convert.ToInt32(Math.Floor(tim%3600/60))}:{Convert.ToInt32(tim%60)}";

        Debug.Log(timer);
    }

    public void InHand()
    {
        if (TagDetecter.hoverTag<37)
        {
            for (int i = 0; i < weapons.Length; i++)
            {
                if (weapons[i].GetNamedChild("[Right Controller] Dynamic Attach") || weapons[i].GetNamedChild("[Left Controller] Dynamic Attach"))
                {
                    weap = true;
                    What(int.Parse(weapons[i].tag));
                }
                else
                    (weapons[i].GetComponent("XRGrabInteractable") as MonoBehaviour).enabled = false;
            }



            void What(int cur_tag)
            {

                switch (cur_tag)
                {
                    case 0:
                        description.text = "Довольно обычная крепкая булава.";
                        rank.text = "2";
                        uron.text = "40";
                        real_uron = 40;
                        break;
                    case 1:
                        description.text = "Простое аккуратное копьё.";
                        rank.text = "2";
                        uron.text = "30";
                        real_uron = 30;
                        break;
                    case 2:
                        description.text = "Копьё, пропитанное слабой тёмной магией.";
                        rank.text = "3";
                        uron.text = "60";
                        real_uron = 60;
                        break;
                    case 3:
                        description.text = "Магическо ядовитое копьё.";
                        rank.text = "4";
                        uron.text = "80";
                        real_uron = 6;
                        break;
                    case 4:
                        description.text = "Зачарованный крабовый меч.";
                        rank.text = "4";
                        uron.text = "75";
                        real_uron = 75;
                        break;
                    case 5:
                        description.text = "Неотёсанный меч космического мага.";
                        rank.text = "3";
                        uron.text = "55";
                        real_uron = 55;
                        break;
                    case 6:
                        description.text = "Загадочное копьё глубин.";
                        rank.text = "4";
                        uron.text = "70";
                        real_uron = 70;
                        break;
                    case 7:
                        description.text = "Неотёсанный меч светлого монаха.";
                        rank.text = "3";
                        uron.text = "55";
                        real_uron = 55;
                        break;
                    case 8:
                        description.text = "Костяная дубина лича.";
                        rank.text = "6";
                        uron.text = "110";
                        real_uron = 110;
                        break;
                    case 9:
                        description.text = "Меч гоблина-некроманта.";
                        rank.text = "5";
                        uron.text = "85";
                        real_uron = 85;
                        break;
                    case 10:
                        description.text = "Меч гоблина Огненных Долин.";
                        rank.text = "5";
                        uron.text = "85";
                        real_uron = 85;
                        break;
                    case 11:
                        description.text = "Рубило 'Монолит'.";
                        rank.text = "6";
                        uron.text = "100";
                        real_uron = 100;
                        break;
                    case 12:
                        description.text = "Поднятый с глубин меч Атлантиды.";
                        rank.text = "3";
                        uron.text = "50";
                        real_uron = 50;
                        break;
                    case 13:
                        description.text = "Разочарованный меч тьмы.";
                        rank.text = "6";
                        uron.text = "95";
                        real_uron = 95;
                        break;
                    case 14:
                        description.text = "Меч драконьего дыхания.";
                        rank.text = "6";
                        uron.text = "95";
                        real_uron = 95;
                        break;
                    case 15:
                        description.text = "Паровая колотушка.";
                        rank.text = "6";
                        uron.text = "95";
                        real_uron = 95;
                        break;
                    case 16:
                        description.text = "Меч ледяного краба.";
                        rank.text = "4";
                        uron.text = "75";
                        real_uron = 75;
                        break;
                    case 17:
                        description.text = "Резак спрутов-киборгов.";
                        rank.text = "3";
                        uron.text = "55";
                        real_uron = 55;
                        break;
                    case 18:
                        description.text = "Лунный факел Олимпа.";
                        rank.text = "3";
                        uron.text = "45";
                        real_uron = 45;
                        break;
                    case 19:
                        description.text = "Прямой резак тёмного утра.";
                        rank.text = "2";
                        uron.text = "30";
                        real_uron = 30;
                        break;
                    case 20:
                        description.text = "Прямой резак сетлого вечера.";
                        rank.text = "3";
                        uron.text = "45";
                        real_uron = 45;
                        break;
                    case 21:
                        description.text = "Древний меч Замёрзшего океана.";
                        rank.text = "5";
                        uron.text = "75";
                        real_uron = 75;
                        break;
                    case 22:
                        description.text = "Неожиданно простой боевой топор.";
                        rank.text = "2";
                        uron.text = "25";
                        real_uron = 25;
                        break;
                    case 23:
                        description.text = "Топор Прожигающего Света.";
                        rank.text = "4";
                        uron.text = "65";
                        real_uron = 65;
                        break;
                    case 24:
                        description.text = "Качественный топор.";
                        rank.text = "3";
                        uron.text = "50";
                        real_uron = 6;
                        break;
                    case 25:
                        description.text = "Секира простака.";
                        rank.text = "3";
                        uron.text = "55";
                        real_uron = 55;
                        break;
                    case 26:
                        description.text = "Секира пламенных чар.";
                        rank.text = "5";
                        uron.text = "90";
                        real_uron = 90;
                        break;
                    case 27:
                        description.text = "секира редкого металла.";
                        rank.text = "4";
                        uron.text = "65";
                        real_uron = 65;
                        break;
                    case 28:
                        description.text = "Посох заклинателя ядов.";
                        rank.text = "6";
                        uron.text = "100";
                        real_uron = 100;
                        break;
                    case 29:
                        description.text = "Потухшая волшебная палочка.";
                        rank.text = "2";
                        uron.text = "30";
                        real_uron = 30;
                        break;
                    case 30:
                        description.text = "Палочка 'Глаз дракона'.";
                        rank.text = "3";
                        uron.text = "45";
                        real_uron = 45;
                        break;
                    case 31:
                        description.text = "тюремный молот Печи.";
                        rank.text = "4";
                        uron.text = "70";
                        real_uron = 70;
                        break;
                    case 32:
                        description.text = "увесистый молот Печи.";
                        rank.text = "5";
                        uron.text = "85";
                        real_uron = 85;
                        break;
                    case 33:
                        description.text = "каменно-энергетический молот Печи.";
                        rank.text = "6";
                        uron.text = "95";
                        real_uron = 95;
                        break;
                    case 34:
                        description.text = "Кирка Начала Турнира.";
                        rank.text = "1";
                        uron.text = "15";
                        real_uron = 15;
                        break;
                    case 35:
                        description.text = "Вилы Начала Турнира.";
                        rank.text = "1";
                        uron.text = "15";
                        real_uron = 15;
                        break;
                    case 36:
                        description.text = "Лопата Начала Турнира.";
                        rank.text = "1";
                        uron.text = "15";
                        real_uron = 15;
                        break;
                }

                SetInt("Uron", real_uron);
            }
        }
    }

    public void OutHand()
    {
        description.text = "Что ж, всего лишь ваши руки.";
        rank.text = "0";
        uron.text = "0";
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
