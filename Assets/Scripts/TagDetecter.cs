using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TagDetecter : MonoBehaviour
{
    public static int hoverTag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("1") || other.tag.Contains("2") || other.tag.Contains("3") || other.tag.Contains("4") || other.tag.Contains("5") || other.tag.Contains("6") || other.tag.Contains("7") || other.tag.Contains("8") || other.tag.Contains("9") || other.tag.Contains("0"))
        {
            hoverTag = Convert.ToInt32(other.tag);
            Debug.Log(hoverTag);            
        }
    }
}
