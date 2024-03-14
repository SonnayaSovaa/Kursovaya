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
                    description.text = "ввв";
                    rank.text = "����: 1";
                    uron.text = "����: 20";
                    real_uron = 20;
                    break;
                case 1:
                    description.text = "��������: ����";
                    rank.text = "����: 2";
                    uron.text = "����: 666";
                    real_uron = 666;
                    break;
                case 2:
                    description.text = "��������: �������";
                    rank.text = "����: 6";
                    uron.text = "����: 12398";
                    real_uron = 12398;
                    break;
            }

            SetInt("Uron", real_uron);
        }

    }

    public void OutHand()
    {
        description.text = "��������: ���� ���� ���";
        rank.text = "����: 0";
        uron.text = "����: ����� ����? � ���� �����";
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
