using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class Health : MonoBehaviour
{

    [SerializeField] private Slider healthSl;
    [SerializeField] Player player;
    int heal;




    private void Start()
    {


        int slojnost=PlayerPrefs.GetInt("LevelDif");
        switch (slojnost)
        {
            case 0:
                heal = 40;
                break;
            case 1:
                heal = 25;
                break;
            case 2:
                heal = 15;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="38")
        {
            player.currhealth+=heal;
            if (healthSl.value * 100 + heal <= 100) healthSl.value = (healthSl.value * 100 + heal) / 100;
            else healthSl.value = 1;

            Destroy(other.gameObject);
        }
    }




}
