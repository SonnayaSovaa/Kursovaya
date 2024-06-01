using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaDoorCheck : MonoBehaviour
{
    [SerializeField] GameObject door;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(door.GetComponent<DoorFromLab>());
        }
    }




}
