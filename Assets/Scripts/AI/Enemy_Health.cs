using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy_Health : MonoBehaviour
{
    //visit na vrage
    int uron;
    int zdorovie;
    int slojnost;
    [SerializeField] private Player player;
    [SerializeField] private Weap_Desc weapon;

    [SerializeField] GameObject vrag;
    private void Start()
    {
        slojnost = PlayerPrefs.GetInt("LevelDif");



        if (this.tag == "77")  //prosto vrag 
        {
            switch (slojnost)
            {
                case 0:
                    uron = 5;
                    zdorovie = 50;
                    break;

                case 1:
                    uron = 10;
                    zdorovie = 80;
                    break;

                case 2:
                    uron = 5;
                    zdorovie = 120;
                    break;

            }
        }
        else
        {
            switch (slojnost)
            {
                case 0:
                    uron = 5;
                    zdorovie = 50;
                    break;

                case 1:
                    uron = 10;
                    zdorovie = 80;
                    break;

                case 2:
                    uron = 5;
                    zdorovie = 120;
                    break;

            }
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            player.GetDamage(uron);
        }
        else if(other.tag.Contains("1") || other.tag.Contains("2") || other.tag.Contains("3") || other.tag.Contains("4") || other.tag.Contains("5") || other.tag.Contains("6") || other.tag.Contains("7") || other.tag.Contains("8") || other.tag.Contains("9") || other.tag.Contains("0"))
        {
            int tagg = Convert.ToInt32(other.tag);
            if (tagg<37 && tagg>=0)
            {
                zdorovie -= weapon.real_uron;
                if (zdorovie <= 0) Death();
            }
        }
    }

    void Death()
    {
        Destroy(vrag);
    }



}
