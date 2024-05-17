using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    //public float attackRange;

    //public float AttackRange => attackRange;

    private Player player;
    public bool boss;
    int slojnost;
    int uron;

    private void Start()
    {
        player = FindObjectOfType<Player>();

        slojnost = PlayerPrefs.GetInt("LevelDif");



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
                    uron = 15;
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

    public void TryAttackPlayer()
    {
        player.GetDamage(uron);
    }



}
