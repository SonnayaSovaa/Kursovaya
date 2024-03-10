using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class GrabRotate : MonoBehaviour
{
    public GameObject sword;

    private void Update()
    {

        //if (sword.GetNamedChild("[Right Controller] Dynamic Attach"))
    }

    public void Rot()
    {
        {
            Debug.Log("Rotate");

            
            sword.GetComponent<Rigidbody>().isKinematic=false;
            //Vector3 rotationToAdd = new Vector3(0, 90, 0); //1

            //Debug.Log(sword.GetComponent<Rigidbody>().isKinematic); 
            //sword.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0)); //2
            //sword.transform.Rotate(rotationToAdd); //1
            //sword.transform.localEulerAngles = new Vector3(0, 90, 0); //4
            transform.Rotate(0, 90, 0); //5

            //sword.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
