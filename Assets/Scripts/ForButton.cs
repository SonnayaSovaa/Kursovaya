using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForButton : MonoBehaviour
{
    public GameObject igrok;
    public GameObject button;
    //public GameObject stats;
    //public GameObject inv;


    private void Update()
    {
        //Debug.Log("NO");

        if (32<igrok.transform.eulerAngles.x && 90> igrok.transform.eulerAngles.x)

        {
            //Debug.Log("YES");
            button.SetActive(true);
        }
        else
        {
            button.SetActive(false);
        }
    }

    public void OnClick()
    {
        //stats.SetActive(true);
        //inv.SetActive(true);
        Debug.Log("WORKING!!");
    }

}
