using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForButton : MonoBehaviour
{
    public GameObject igrok;
    public GameObject button;
    public GameObject nastr;
    public GameObject inv;

    private bool SetNastr = false;
    public static bool SetInv = false;


    public GameObject point1;

    private void Update()
    {
        //Debug.Log("NO");

        if (40<igrok.transform.eulerAngles.x && 90> igrok.transform.eulerAngles.x)

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
        SetInv = !SetInv;
        SetNastr = !SetNastr;

        nastr.SetActive(SetNastr);
        inv.SetActive(SetInv);
        Debug.Log("WORKING!!");
    }

}
