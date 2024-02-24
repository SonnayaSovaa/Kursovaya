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
        opisanie.text = opisanie.text = "������ � ��������� �����, ����� �������, ������� ����.";
    }
    public void ValChange()
    {
        switch(drdw.value)
        {
            case 0:
                opisanie.text = "������ � ��������� �����, ����� �������, ������� ����.";
                break;

            case 1:
                opisanie.text = "������� � ��������� �����, ����������� ���������� �������, ���������� ����.";
                break;

            case 2:
                opisanie.text = "������� � ������� �����, ���� �������, ������� ����.";
                break;

        }
    }
}
