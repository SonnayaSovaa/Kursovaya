using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
   [SerializeField] private Animator animator;
   [SerializeField] private Enemy enemy;

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

         case EnemyStates.Attack:
                animator.SetBool("roam", false);
                animator.SetBool("following", false);
                animator.SetBool("attack", true);
                break;

         case EnemyStates.Dead:
                animator.SetBool("roam", false);
                animator.SetBool("following", false);
                animator.SetBool("attack", false);
                animator.SetBool("dead", true);
                break;

        } 
   }
}
