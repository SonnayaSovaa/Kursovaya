using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gain_Rot : MonoBehaviour
{
    void Update()
    {
        this.transform.Rotate(0, 10 * Time.deltaTime, 0);
    }
}
