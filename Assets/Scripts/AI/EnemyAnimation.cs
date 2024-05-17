using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
   [SerializeField] private Animator animator;
   [SerializeField] private Enemy enemy;

    private static readonly int Attack = Animator.StringToHash("attack");
    private static readonly int Run = Animator.StringToHash("follow");
    private static readonly int Walk = Animator.StringToHash("roam");
    private static readonly int Dead = Animator.StringToHash("dead");


    public void PlayAttack(bool cond)
    {
        animator.SetBool(Attack, cond);
    }

    public void PlayDead()
    {
        animator.SetTrigger(Dead);
    }


    public void IsRunning(bool condition)
    {
        animator.SetBool(Run, condition);
    }

    public void IsWalk(bool condition)
    {
        animator.SetBool(Walk, condition);
    }

    /*
    private void Update()
   {
        Debug.Log("STATE" +enemy.currState);

      switch (enemy.currState)
      {
         case EnemyStates.Roaming:
                animator.SetBool("follow", false);
                animator.SetBool("attack", false);
                animator.SetBool("roam", true);
                break;

         case EnemyStates.Following:
                animator.SetBool("roam", false);
                animator.SetBool("attack", false);
                animator.SetBool("follow", true);
                break;

        } 
   }*/
}
