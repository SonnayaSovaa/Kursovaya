using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy_Health : MonoBehaviour
{
    //visit na vrage
    int uron;
    int slojnost;

    private Player player;
    private Weap_Desc weapon;
    [SerializeField] private Enemy enemy;

    public bool att_coll;

    public bool boss;

    [SerializeField] AudioClip udar;


    private void Start()
    {
        slojnost = PlayerPrefs.GetInt("LevelDif");

        player = FindObjectOfType<Player>();
        weapon = FindObjectOfType<Weap_Desc>();

        if (!boss)  //prosto vrag 
        {
            switch (slojnost)
            {
                case 0:
                    uron = 5;
                    break;

                case 1:
                    uron = 10;
                    break;

                case 2:
                    uron = 5;
                    break;

            }
        }
        else
        {
            switch (slojnost)
            {
                case 0:
                    uron = 15;
                    break;

                case 1:
                    uron = 20;
                    break;

                case 2:
                    uron = 25;
                    break;

            }
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player" && att_coll)
        {
            player.GetDamage(uron);
        }
        else if(other.tag.Contains("1") || other.tag.Contains("2") || other.tag.Contains("3") || other.tag.Contains("4") || other.tag.Contains("5") || other.tag.Contains("6") || other.tag.Contains("7") || other.tag.Contains("8") || other.tag.Contains("9") || other.tag.Contains("0"))
        {

            int tagg = Convert.ToInt32(other.tag);
            if (tagg<37 && tagg>=0)
            {
                player.playerAudio.PlayOneShot(udar);
                enemy.health -= weapon.real_uron;
            }
        }
    }


}
