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
    public bool SetInv = false;

    public static bool chek = false;

    private void Update()
    {
        chek = SetInv;

        if (40<igrok.transform.eulerAngles.x && 90> igrok.transform.eulerAngles.x)

        {
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
    }

}
