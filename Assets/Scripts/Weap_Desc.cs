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
        if (Rayyy.hoverTag<37)
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
                        description.text = "Описание: Довольно обычная крепкая булава.";
                        rank.text = "Ранг: 2";
                        uron.text = "Урон: 40";
                        real_uron = 40;
                        break;
                    case 1:
                        description.text = "Описание: Простое аккуратное копьё.";
                        rank.text = "Ранг: 2";
                        uron.text = "Урон: 30";
                        real_uron = 30;
                        break;
                    case 2:
                        description.text = "Описание: Копьё, пропитанное слабой тёмной магией.";
                        rank.text = "Ранг: 3";
                        uron.text = "Урон: 60";
                        real_uron = 60;
                        break;
                    case 3:
                        description.text = "Описание: Магическо ядовитое копьё.";
                        rank.text = "Ранг: 4";
                        uron.text = "Урон: 80";
                        real_uron = 6;
                        break;
                    case 4:
                        description.text = "Описание: Зачарованный крабовый меч.";
                        rank.text = "Ранг: 4";
                        uron.text = "Урон: 75";
                        real_uron = 75;
                        break;
                    case 5:
                        description.text = "Описание: Неотёсанный меч космического мага.";
                        rank.text = "Ранг: 3";
                        uron.text = "Урон: 55";
                        real_uron = 55;
                        break;
                    case 6:
                        description.text = "Описание: Загадочное копьё глубин.";
                        rank.text = "Ранг: 4";
                        uron.text = "Урон: 70";
                        real_uron = 70;
                        break;
                    case 7:
                        description.text = "Описание: Неотёсанный меч светлого монаха.";
                        rank.text = "Ранг: 3";
                        uron.text = "Урон: 55";
                        real_uron = 55;
                        break;
                    case 8:
                        description.text = "Описание: Костяная дубина лича.";
                        rank.text = "Ранг: 6";
                        uron.text = "Урон: 110";
                        real_uron = 110;
                        break;
                    case 9:
                        description.text = "Описание: Меч гоблина-некроманта.";
                        rank.text = "Ранг: 5";
                        uron.text = "Урон: 85";
                        real_uron = 85;
                        break;
                    case 10:
                        description.text = "Описание: Меч гоблина Огненных Долин.";
                        rank.text = "Ранг: 5";
                        uron.text = "Урон: 85";
                        real_uron = 85;
                        break;
                    case 11:
                        description.text = "Описание: Рубило 'Монолит'.";
                        rank.text = "Ранг: 6";
                        uron.text = "Урон: 100";
                        real_uron = 100;
                        break;
                    case 12:
                        description.text = "Описание: Поднятый с глубин меч Атлантиды.";
                        rank.text = "Ранг: 3";
                        uron.text = "Урон: 50";
                        real_uron = 50;
                        break;
                    case 13:
                        description.text = "Описание: Разочарованный меч тьмы.";
                        rank.text = "Ранг: 6";
                        uron.text = "Урон: 95";
                        real_uron = 95;
                        break;
                    case 14:
                        description.text = "Описание: Меч драконьего дыхания.";
                        rank.text = "Ранг: 6";
                        uron.text = "Урон: 95";
                        real_uron = 95;
                        break;
                    case 15:
                        description.text = "Описание: Паровая колотушка.";
                        rank.text = "Ранг: 6";
                        uron.text = "Урон: 95";
                        real_uron = 95;
                        break;
                    case 16:
                        description.text = "Описание: Меч ледяного краба.";
                        rank.text = "Ранг: 4";
                        uron.text = "Урон: 75";
                        real_uron = 75;
                        break;
                    case 17:
                        description.text = "Описание: Резак спрутов-киборгов.";
                        rank.text = "Ранг: 3";
                        uron.text = "Урон: 55";
                        real_uron = 55;
                        break;
                    case 18:
                        description.text = "Описание: Лунный факел Олимпа.";
                        rank.text = "Ранг: 3";
                        uron.text = "Урон: 45";
                        real_uron = 45;
                        break;
                    case 19:
                        description.text = "Описание: Прямой резак тёмного утра.";
                        rank.text = "Ранг: 2";
                        uron.text = "Урон: 30";
                        real_uron = 30;
                        break;
                    case 20:
                        description.text = "Описание: Прямой резак сетлого вечера.";
                        rank.text = "Ранг: 3";
                        uron.text = "Урон: 45";
                        real_uron = 45;
                        break;
                    case 21:
                        description.text = "Описание: Древний меч Замёрзшего океана.";
                        rank.text = "Ранг: 5";
                        uron.text = "Урон: 75";
                        real_uron = 75;
                        break;
                    case 22:
                        description.text = "Описание: Неожиданно простой боевой топор.";
                        rank.text = "Ранг: 2";
                        uron.text = "Урон: 25";
                        real_uron = 25;
                        break;
                    case 23:
                        description.text = "Описание: Топор Прожигающего Света.";
                        rank.text = "Ранг: 4";
                        uron.text = "Урон: 65";
                        real_uron = 65;
                        break;
                    case 24:
                        description.text = "Описание: Качественный топор.";
                        rank.text = "Ранг: 3";
                        uron.text = "Урон: 50";
                        real_uron = 6;
                        break;
                    case 25:
                        description.text = "Описание: Секира простака.";
                        rank.text = "Ранг: 3";
                        uron.text = "Урон: 55";
                        real_uron = 55;
                        break;
                    case 26:
                        description.text = "Описание: Секира пламенных чар.";
                        rank.text = "Ранг: 5";
                        uron.text = "Урон: 90";
                        real_uron = 90;
                        break;
                    case 27:
                        description.text = "Описание: секира редкого металла.";
                        rank.text = "Ранг: 4";
                        uron.text = "Урон: 65";
                        real_uron = 65;
                        break;
                    case 28:
                        description.text = "Описание: Посох заклинателя ядов.";
                        rank.text = "Ранг: 6";
                        uron.text = "Урон: 100";
                        real_uron = 100;
                        break;
                    case 29:
                        description.text = "Описание: Потухшая волшебная палочка.";
                        rank.text = "Ранг: 2";
                        uron.text = "Урон: 30";
                        real_uron = 30;
                        break;
                    case 30:
                        description.text = "Описание: Палочка 'Глаз дракона'.";
                        rank.text = "Ранг: 3";
                        uron.text = "Урон: 45";
                        real_uron = 45;
                        break;
                    case 31:
                        description.text = "Описание: тюремный молот Печи.";
                        rank.text = "Ранг: 4";
                        uron.text = "Урон: 70";
                        real_uron = 70;
                        break;
                    case 32:
                        description.text = "Описание: увесистый молот Печи.";
                        rank.text = "Ранг: 5";
                        uron.text = "Урон: 85";
                        real_uron = 85;
                        break;
                    case 33:
                        description.text = "Описание: каменно-энергетический молот Печи.";
                        rank.text = "Ранг: 6";
                        uron.text = "Урон: 95";
                        real_uron = 95;
                        break;
                    case 34:
                        description.text = "Описание: Кирка Начала Турнира.";
                        rank.text = "Ранг: 1";
                        uron.text = "Урон: 15";
                        real_uron = 15;
                        break;
                    case 35:
                        description.text = "Описание: Вилы Начала Турнира.";
                        rank.text = "Ранг: 1";
                        uron.text = "Урон: 15";
                        real_uron = 15;
                        break;
                    case 36:
                        description.text = "Описание: Лопата Начала Турнира.";
                        rank.text = "Ранг: 1";
                        uron.text = "Урон: 15";
                        real_uron = 15;
                        break;
                }

                SetInt("Uron", real_uron);
            }
        }
    }

    public void OutHand()
    {
        description.text = "Описание: Что ж, всего лишь ваши руки.";
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
