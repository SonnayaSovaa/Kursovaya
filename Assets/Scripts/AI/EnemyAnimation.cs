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
      switch (enemy.currState)
      {
         case EnemyStates.Roaming:
            animator.SetBool("roam", true);
            animator.SetBool("follow", false);
            break;
         case EnemyStates.Following:
            animator.SetBool("follow", true);
            animator.SetBool("roam", false);
            break;
         //потом добавлю сюда анимацию атаки
      } 
   }
}
