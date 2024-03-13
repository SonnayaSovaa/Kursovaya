using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.XR.CoreUtils;

public class Weap_Desc : MonoBehaviour
{
    [SerializeField] TMP_Text description;
    [SerializeField] TMP_Text rank;
    [SerializeField] TMP_Text uron;
    public void InHand()
    {
        if (this.gameObject.GetNamedChild(""))
        {

            int currTag = int.Parse(this.gameObject.tag);

            switch (currTag)
            {
                case 0:
                    description.text = "Ноль вообще";
                    rank.text = "1";
                    uron.text = "20";
                    break;
                case 1:
                    description.text = "Адын";
                    rank.text = "2";
                    uron.text = "666";
                    break;
                case 2:
                    description.text = "ДВААААА";
                    rank.text = "6";
                    uron.text = "12398";
                    break;
            }
        }

    }




}
