using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityRandom = UnityEngine.Random;
using Redcode.Extensions;

namespace Shooter
{
	public class CharacterController : Unit
	{
		[SerializeField]
		[Range(0f, 10f)]
		private float _speed = 1f;

		public event Action<CharacterController, float> Damaged; 
		
		private void Update()
		{
			//var horizontal = Input.GetAxis("Horizontal");
			//var vertical = Input.GetAxis("Vertical");

			// direction = new Vector3(horizontal, 0f, vertical);
			//direction = Camera.main.transform.TransformDirection(direction);;
			//direction.y = 0;
			//direction.Normalize();
			
			//transform.position += direction * (_speed * Time.deltaTime);
		}

		public override void TakeDamage(int damage)
		{
			base.TakeDamage(damage);
			Damaged?.Invoke(this, _health / (float)_maxHealth);
		}
	}
}