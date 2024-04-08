using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Chest_Random : MonoBehaviour
{

    public GameObject[] weapons;
    public GameObject[] heal;
    public GameObject[] chests;

    string used = " ";

    private void Start()
    {
        Debug.Log("START");
        

        foreach (GameObject che in chests) 
        {
            int Wrand = randomaizer(used, weapons.Length);

            used = used + " " + Wrand.ToString() + " ";

            Debug.Log("used " + used);

            GameObject w =Instantiate(weapons[Wrand], che.transform);

            w.transform.parent = che.transform;
            w.transform.position = che.transform.position;
            w.transform.position += new Vector3(0, 0.5f, 0);
            w.transform.localScale = new Vector3 (0.1f, 0.1f, 0.1f);



            int Hrand = randomaizer(used, heal.Length);

            Debug.Log("used " + used);

            GameObject h = Instantiate(weapons[Hrand], che.transform);

            h.transform.parent = che.transform;
            h.transform.position = che.transform.position;
            h.transform.position += new Vector3(0, 0.5f, 0);
            h.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        }


        Debug.Log("used "+used);

    }
     

    int randomaizer(string used, int gran)
    {
        int a = Random.Range(0, gran);
        while (used.Contains(" "+a.ToString()+" "))
        {
            a=Random.Range(0, weapons.Length);
            
        }
        return a;
    }

}
