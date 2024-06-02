using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityRandom = UnityEngine.Random;

namespace Shooter
{
	public class Enemy : Unit
	{
		[SerializeField]
		private NavMeshAgent _agent;

		[SerializeField]
		private float _distanceToAttack;

		[SerializeField]
		private int _damage;

		[SerializeField]
		private float _attackInterval; 
		
		public void StartHunting(CharacterController character) => StartCoroutine(StartHuntingEnumerator(character));
		
		private IEnumerator StartHuntingEnumerator(CharacterController character)
		{
			StartCoroutine(AttackEnumerator(character));
			
			while (true)
			{
				_agent.SetDestination(character.transform.position);
				yield return new WaitForSeconds(0.2f);
			}
		}

		private IEnumerator AttackEnumerator(CharacterController character)
		{
			while (true)
			{
				yield return null;

				if (Vector3.Distance(transform.position, character.transform.position) <= _distanceToAttack)
				{
					character.TakeDamage(_damage);
					yield return new WaitForSeconds(_attackInterval);
				}
			}
		}
	}
}