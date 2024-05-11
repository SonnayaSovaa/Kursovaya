using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UIElements;

public class Chest_Random : MonoBehaviour
{

    public GameObject[] weapons;
    public GameObject[] heal;
    public GameObject[] chests;

    string used = " ";
    string usedH = " ";

    private void Start()
    {
        Debug.Log("START");
        

        foreach (GameObject che in chests) 
        {
            int Wrand = randomaizer(used, weapons.Length);

            used = used + " " + Wrand.ToString() + " ";

            //Debug.Log("used " + used);

            //GameObject w =Instantiate(weapons[Wrand], che.transform);

            weapons[Wrand].transform.parent = che.transform;
            weapons[Wrand].transform.position = che.transform.position;
            
            weapons[Wrand].transform.position += new Vector3(0, 1.1f, 0);
            weapons[Wrand].transform.localScale = new Vector3 (weapons[Wrand].transform.localScale.x*0.001f, weapons[Wrand].transform.localScale.y * 0.001f, weapons[Wrand].transform.localScale.z * 0.001f);
            

            
            int Hrand = randomaizer(usedH, heal.Length);
            usedH = usedH + " " + Hrand.ToString() + " ";
            //Debug.Log("used " + used);

            //GameObject h = Instantiate(heal[Hrand], che.transform);

            heal[Hrand].transform.parent = che.transform;
            heal[Hrand].transform.position = che.transform.position;
            heal[Hrand].transform.position += new Vector3(0, 1.1f, 0);
            heal[Hrand].transform.localScale = new Vector3(heal[Hrand].transform.localScale.x * 0.001f, heal[Hrand].transform.localScale.y * 0.001f, heal[Hrand].transform.localScale.z * 0.001f);
            
        }


        Debug.Log("used "+used);

    }
     

    int randomaizer(string used, int gran)
    {
        int a = Random.Range(0, gran);
        while (used.Contains(" "+a.ToString()+" "))
        {
            a=Random.Range(0, gran);
            
        }
        return a;
    }

}
