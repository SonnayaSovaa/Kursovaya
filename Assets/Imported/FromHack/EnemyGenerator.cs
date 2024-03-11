using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Redcode.Extensions;
using UnityEngine;
using UnityRandom = UnityEngine.Random;

namespace Shooter
{
	public class EnemyGenerator : MonoBehaviour
	{
		[SerializeField]
		private float _interval;

		[SerializeField]
		private Enemy[] _enemiesPrefabs;

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
				var enemy = Instantiate(_enemiesPrefabs.GetRandomElement(), transform, true);

				var direction = UnityRandom.insideUnitCircle.InsertY().normalized;
				var outsideScreenPos = (_character.transform.position + direction * _radius).Clamp(_minMaxSide.x, _minMaxSide.y);
				enemy.transform.position = outsideScreenPos;

				enemy.StartHunting(_character);
			}
		}
	}
}