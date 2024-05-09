using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotation : MonoBehaviour
{
    private float X, Y, Z;
    public int speeds=10;
    private float eulerX = 0, eulerY = 0;
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        X = Input.GetAxis("Mouse X") * speeds * Time.deltaTime;
        Y = -Input.GetAxis("Mouse Y") * speeds * Time.deltaTime;
        eulerX = (transform.rotation.eulerAngles.x + Y) % 360;
        eulerY = (transform.rotation.eulerAngles.y + X) % 360;
        transform.rotation = Quaternion.Euler(eulerX, eulerY, 0);
        if (Input.GetKeyUp(KeyCode.Escape))
        {
           //Cursor.lockState = CursorLockMode.None;
        }
    }
}