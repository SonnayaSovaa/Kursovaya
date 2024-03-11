using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityRandom = UnityEngine.Random;

namespace Shooter
{
	public class Unit : MonoBehaviour
	{
		[SerializeField]
		protected int _health;

		protected int _maxHealth;
		
		private void Awake() => _maxHealth = _health;

		public virtual void TakeDamage(int damage) => _health = Mathf.Max(_health - damage, 0);
	}
}