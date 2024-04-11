using System;
using UnityEngine;
public class Inventory : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        int local =Convert.ToInt32(other.tag);
        if (local < 38)
            this.gameObject.SetActive(false);
            //(this.gameObject.GetComponent("XRSocketInteractor") as MonoBehaviour).enabled = false;

    }

    private void OnTriggerExit(Collider other)
    {
        this.gameObject.SetActive(true);
    }


}
