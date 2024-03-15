using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Redcode.Extensions;
using UnityEngine;
using UnityRandom = UnityEngine.Random;

namespace Kursovaya
{
	public class EnemyGenerat : MonoBehaviour
	{
		[SerializeField]
		private float _interval;

		[SerializeField]
		private GameObject _enemiesPrefabs;

		[SerializeField]
		private CharacterController _character;

		[SerializeField]
		private float _radius;

		[SerializeField]
		private Vector2 _minMaxSide;

		private IEnumerator Start()
		{
			while (true)
			{
				yield return new WaitForSeconds(_interval);
				var enemy = Instantiate(_enemiesPrefabs, transform, true);

				var direction = UnityRandom.insideUnitCircle.InsertY().normalized;
				var outsideScreenPos = (_character.transform.position + direction * _radius).Clamp(_minMaxSide.x, _minMaxSide.y);
				enemy.transform.position = outsideScreenPos;

				//enemy.StartHunting(_character);
			}
		}
		
	}
}