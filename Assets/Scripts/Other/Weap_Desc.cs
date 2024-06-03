using System;
using probnik;
using UnityEngine;
using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine.SceneManagement;

public class Weap_Desc : MonoBehaviour
{
    [SerializeField] public TMP_Text description;
    [SerializeField] public TMP_Text rank;
    [SerializeField] public TMP_Text uron;

    [SerializeField] private WeaponGrab Left;
    [SerializeField] private WeaponGrab Right;
    //[SerializeField] GameObject igrok;
    //[SerializeField] Player player;
    private void Update()
    {
        if (Left.inhand)
        {
            description.text = Left.description;
            rank.text = Left.rank;
            uron.text = Convert.ToString(Left.real_uron);
        }
        else
        {
            if (Right.inhand)
            {
                description.text = Right.description;
                rank.text = Right.rank;
                uron.text = Convert.ToString(Right.real_uron);
            }
            else
            {
                description.text = "Что ж, всего лишь ваши руки.";
                rank.text = "0";
                uron.text = "0";
            }
        }
    }
}
