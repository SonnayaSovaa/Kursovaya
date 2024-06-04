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
		public string tagg;
		
		private void OnTriggerEnter(Collider other)
		{
			
			if (other.gameObject.GetComponent<TheWeapon>()!=null)
			{ 
				wep = other.gameObject.GetComponent<TheWeapon>();	
				
				weap = other.gameObject;
				weap.transform.SetParent(igrok.transform);
				description = wep.description;
				rank = wep.rank;
				real_uron = wep.real_uron;
				inhand = true;
				tagg = other.tag;
			}
		}
		private void OnTriggerExit(Collider other)
		{
			Debug.Log("hfnfmdtugkm,f yg");
			if (other.gameObject.GetComponent<TheWeapon>()!=null)
			{ 
				weap.transform.SetParent(null);
				//weap = null;
				inhand = false;
				real_uron = 0;
				tagg = null;
			}
				
		}

	}
}