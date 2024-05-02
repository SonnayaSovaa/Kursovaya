using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PipeRotate : MonoBehaviour
{
    Transform[] Pipes;
    public GameObject[] Pipes20 = new GameObject[67];
    int[] Pipe_vals = new int[67];


    public ActionBasedController controller_L;
    public ActionBasedController controller_R;

    private void Start()
    {
        Pipes=this.gameObject.GetComponentsInChildren<Transform>();
       
        int j = 0;
        for (int i=Pipes.Length-1; i>=0; i--)
        {
            if (!(Pipes[i].gameObject.name.Contains("_")|| Pipes[i].gameObject.name.Contains("Tru")))
            {
                Pipes20[j] = Pipes[i].gameObject;
                j++;
            }
        }

        

        int a = 0;
        
        foreach (GameObject pipe in Pipes20)
        {
            Pipe_vals[a] =System.Convert.ToInt32( pipe.transform.rotation.z);
            a++;
        }

        Shuffle();

    }


    void Check()
    {

        int i = 0;
        bool flag = true;
        foreach (GameObject pipe in Pipes20)
        {
            if (pipe.transform.eulerAngles.z != Pipe_vals[i])
            { flag = false; break; }
            else
                i++;
        }
        if (flag == true)
        {
            Debug.Log("WIN");
        }

    }

    void Shuffle()
    {
        
        int[] ang = new int[] { 90, 270, 180, 0 };
        for (int r=0; r< Pipes20.Length-1; r++)
        {
            int a = Random.Range(0, 4);


            Vector3 newRotation = new Vector3(0, 0, ang[a]*1f);
            Pipes20[r].transform.eulerAngles += newRotation;
            Debug.Log("S");
        }
       
    }

}
