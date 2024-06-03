using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityRandom = UnityEngine.Random;

namespace probnik
{
	public class WeaponGrab : MonoBehaviour
	{
		[SerializeField] private GameObject igrok;
		public GameObject weap;
		public bool inhand;
		public string description;
		public string rank;
		public int real_uron;
		public TheWeapon wep;
		
		private void OnTriggerEnter(Collider other)
		{
			Debug.Log("COOLIDER");
			if (GetComponent("TheWeapon")!=null)
			{ 
				wep = GetComponent("TheWeapon");	
				Debug.Log("COOOOOOOOOOOOOLIDER");
				weap = other.gameObject;
				weap.transform.SetParent(igrok.transform);
				description = wep.description;
				rank = wep.rank;
				real_uron = wep.real_uron;
				inhand = true;
			}
		}
		private void OnTriggerExit(Collider other)
		{
			if (TryGetComponent<TheWeapon>(out TheWeapon wep))
			{
				other.transform.parent = null;
				//weap = null;
				inhand = false;
				real_uron = 0;
			}
		}

	}
}