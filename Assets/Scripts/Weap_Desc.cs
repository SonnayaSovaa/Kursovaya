using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.XR.CoreUtils;
using Unity.VisualScripting;
using UnityEditor.Presets;
//using Unity.XR.Oculus;
//using Unity.XR.Oculus.Input;
using UnityEngine.XR.Interaction.Toolkit;

public class Weap_Desc : MonoBehaviour
{
    [SerializeField] TMP_Text description;
    [SerializeField] TMP_Text rank;
    [SerializeField] TMP_Text uron;

    public static int real_uron;

    public GameObject[] weapons;

    RaycastHit hit; 

    int hover_tag;

    bool weap=false;

    public void ON_Hover()
    {
        if (weap)
        {
            hover_tag = int.Parse(hit.collider.tag);
            if (hover_tag >= 0 && hover_tag < 37)
                (weapons[hover_tag].GetComponent("XR Grab Interactable") as MonoBehaviour).enabled = false;
        }
    }

    public void OUT_Hover()
    {
        if (weap)
            (weapons[hover_tag].GetComponent("XR Grab Interactable") as MonoBehaviour).enabled = true;
    }

    
    public void InHand()
    {
        foreach (var i in weapons)
        {
            if (i.GetNamedChild("[Right Controller] Dynamic Attach") || i.GetNamedChild("[Left Controller] Dynamic Attach"))
            {
                weap=true;
                What(int.Parse(i.tag));
                break;

            }
        }



        void What(int cur_tag)
        {

            switch (cur_tag)
            {
                case 0:
                    description.text = "��������: ���� ������";
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
    }


    public void SetInt(string KeyName, int Value)
    {
        PlayerPrefs.SetInt(KeyName, Value);
    }

}
