using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UIElements;

public class MagicCube : MonoBehaviour
{

    public GameObject[] points = new GameObject[9];
    int[] vals = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    bool che;

    private void Update()
    {
        Check();
        
    }


    private void Check()
    {
        int was= 0;

        foreach (GameObject point in points)
        {
            Transform[] childs = point.GetComponentsInChildren<Transform>();
            foreach (Transform chil in childs)
                if (childs.Length!=0 && chil.name.Contains("Attach")) //
                {
                    int  a = Convert.ToInt32(Convert.ToString(chil.name[1]));

                   vals[a-1] =Convert.ToInt32(point.name);
                    was++;
                    break;
                }

            Debug.Log("WAS   " + point.GetComponentInParent<Transform>().name);
        }


        bool hor=false, ver=false, dia = false;


        if (was ==9)
        {
            hor = (vals[0] + vals[1] + vals[2] == vals[3] + vals[4] + vals[5] && vals[6] + vals[7] + vals[8] == vals[0] + vals[1] + vals[2]);
            ver = (vals[0] + vals[3] + vals[6] == vals[1] + vals[4] + vals[7] && vals[0] + vals[3] + vals[6] == vals[2] + vals[5] + vals[8]);
            dia = (vals[0] + vals[8] == vals[2] + vals[6]);

            Debug.Log("HOR   " + hor);
            Debug.Log("VER   " + ver);
            Debug.Log("DIA   " + dia);

            if (hor && ver && dia && vals[0] != 0 && vals[1] != 0 && vals[2] != 0 && vals[3] != 0 && vals[4] != 0 && vals[5] != 0 && vals[6] != 0 && vals[7] != 0 && vals[8] != 0)
            {
                Debug.Log("MAGIC   +++");
            }
            else Debug.Log("MAGIC  ---");
        }



       

    }
    

}
