using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;

public class TagDetecter : MonoBehaviour
{
    public static int hoverTag;

    public ActionBasedController controller_L;
    public ActionBasedController controller_R;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("1") || other.tag.Contains("2") || other.tag.Contains("3") || other.tag.Contains("4") || other.tag.Contains("5") || other.tag.Contains("6") || other.tag.Contains("7") || other.tag.Contains("8") || other.tag.Contains("9") || other.tag.Contains("0"))
        {
            hoverTag = Convert.ToInt32(other.tag);
            Debug.Log("HOVERTAG    " + hoverTag);
        }
    }

    /*
    int rotated = 0;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "41")
        {

            if ((this.tag == "Left" && controller_L.selectAction.action.ReadValue<float>() > 0 || this.tag == "Right" && controller_R.selectAction.action.ReadValue<float>() > 0))
            {
                Debug.Log("PIPE");
                if (rotated == 0)
                {
                    other.gameObject.transform.eulerAngles += new Vector3(0, 0, 90f);

                }
            }
        }
    }*/

}
