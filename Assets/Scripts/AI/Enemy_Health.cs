using UnityEngine;
using System;
using probnik;
using Unity.VisualScripting;

public class Enemy_Health : MonoBehaviour
{
    //visit na vrage
    int uron;
    int slojnost;

    private Player player;
    [SerializeField] private Enemy enemy;

    public bool att_coll;

    public bool boss;

    private TheWeapon weapon;

    public AudioSource main;

    [SerializeField] AudioClip udar;

    float timer=0;


    private void Start()
    {
        slojnost = PlayerPrefs.GetInt("LevelDif");

        main= FindObjectOfType<AudioSource>();

        player = FindObjectOfType<Player>();

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
                    uron = 25;
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

    private void Update()
    {
        timer += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("udar");
        if (other.tag == "Player" && att_coll)
        {
            player.GetDamage(uron);
        }
        else 
        {
               // int tagg = Convert.ToInt32(other.tag);
                if (other.gameObject.GetComponent<TheWeapon>()!=null)
                {
                    Debug.Log("UDARRRRRRR");
                    if (timer >= 2)
                    {
                        weapon = other.gameObject.GetComponent<TheWeapon>();
                        //weapon = FindObjectOfType<CurrentWeapon>();
                        main.PlayOneShot(udar);
                        enemy.health -= weapon.real_uron;
                        timer = 0;
                    }
                }
                
            
        }
    }


}
