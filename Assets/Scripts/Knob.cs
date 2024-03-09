using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knob : MonoBehaviour
{
    public void Poke()
    {
        for (int i = 0; i < 100; i++)
        {
            this.gameObject.transform.position += new Vector3(0, -0.005f, 0);
        }
        
    }
}
