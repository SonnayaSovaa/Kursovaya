using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class Health : MonoBehaviour
{

    [SerializeField] private Slider healthSl;
    [SerializeField] Player player;
    int heal;


    [SerializeField] private Image health1;
    [SerializeField] private Image health2;
    [SerializeField] private Image health3;
    [SerializeField] private Image health4;

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
            if (player.currhealth + heal > 100)
            {
                player.currhealth = 100;
                healthSl.value = 100;
            }
            else
            {
                player.currhealth += heal;
                healthSl.value = player.currhealth;
            }


            health1.color = new Color(1, 1, 1, 1 - player.currhealth / 100);
            health2.color = new Color(1, 1, 1, 1 - player.currhealth / 100);
            health3.color = new Color(1, 1, 1, 1 - player.currhealth / 100);
            health4.color = new Color(1, 1, 1, 1 - player.currhealth / 100);

            (other.gameObject.GetComponent<XRGrabInteractable>() as MonoBehaviour).enabled = false;

            Destroy(other.gameObject);
        }
    }




}
