using UnityEngine;
using UnityEngine.UI;

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
            player.currhealth+=heal;
            if (healthSl.value * 100 + heal <= 100) healthSl.value = (healthSl.value * 100 + heal) / 100;
            else healthSl.value = 1;


            health1.color = new Color(0, 0, 0, 1 - player.currhealth / 100);
            health2.color = new Color(0, 0, 0, 1 - player.currhealth / 100);
            health3.color = new Color(0, 0, 0, 1 - player.currhealth / 100);
            health4.color = new Color(0, 0, 0, 1 - player.currhealth / 100);

            Destroy(other.gameObject);
        }
    }




}
