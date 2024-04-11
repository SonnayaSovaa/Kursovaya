using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.XR.CoreUtils;
using UnityEngine;

public class MagicCube : MonoBehaviour
{

    public GameObject[] points = new GameObject[9];
    int[] vals = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0};

    private void Update()
    {
        bool r = Check();
        Debug.Log("MAGIC      " + r);
    }
    

    private bool Check()
    {
        int i = 0;
        foreach (var point in points)
        {
            Transform a = point.GetComponentInChildren<Transform>();
            if (a==null)
                vals[i] = 0;
            else
                vals[i]=Convert.ToInt32(a.name);
        }


        bool hor = (vals[0]+vals[1]+vals[2]== vals[3] + vals[4] + vals[5] && vals[6] + vals[7] + vals[8] == vals[0] + vals[1] + vals[2]);
        bool ver = (vals[0] + vals[3] + vals[6] == vals[1] + vals[4] + vals[7] && vals[0] + vals[3] + vals[6] == vals[2] + vals[5] + vals[8]);
        bool dia = (vals[0] + vals[8]== vals[2] + vals[7]);


        return hor&&ver&&dia&&vals[0]!=0 && vals[1] != 0 && vals[2] != 0 && vals[3] != 0 && vals[4] != 0 && vals[5] != 0 && vals[6] != 0 && vals[7] != 0 && vals[8] != 0;


    }

}
