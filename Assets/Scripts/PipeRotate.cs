using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PipeRotate : MonoBehaviour
{
    Transform[] Pipes;
    public GameObject[] Pipes20 = new GameObject[68];
    public int[] Pipe_vals = new int[68];


    public ActionBasedController controller_L;
    public ActionBasedController controller_R;

    [SerializeField] private GameObject win_flag;

    public int[] currRots = new int[68];

    private void Start()
    {
        Pipes=this.gameObject.GetComponentsInChildren<Transform>();
       
        int j = 0;
        for (int i=Pipes.Length-1; i>=0; i--)
        {
            if (!(Pipes[i].gameObject.name.Contains("_")|| Pipes[i].gameObject.name.Contains("For")))
            {
                Pipes20[j] = Pipes[i].gameObject;
                j++;
            }
        }

        

        int a = 0;

        foreach (GameObject pipe in Pipes20)
        {
            Pipe_vals[a] =System.Convert.ToInt32( pipe.transform.localEulerAngles.z);
            a++;
        }

        Shuffle();
    }

    private void Update()
    {
       // Debug.Log("pipevals  "+Pipe_vals);
        Check();
        
    }

    private void Check()
    {
        
        bool flag = true;
        for (int i = 0; i < Pipes20.Length; i++)
        {
            int currRot = System.Convert.ToInt32(Pipes20[i].transform.localEulerAngles.z);
            //if (currRot == 270) currRot = -90;
            if (Pipes20[i].name.Contains("1 (") && currRot == 180) currRot = 0;
            if (Pipes20[i].name.Contains("1 (") && currRot == -90) currRot = 90;
            if (Pipes20[i].name.Contains("1 (") && currRot == 270) currRot = 90;


            //if ((Pipes20[i].name.Contains("1 (") && ((Mathf.Abs(currRot) % 180 != Mathf.Abs(Pipe_vals[i]) % 180))) || currRot != Pipe_vals[i])
            //{ flag = false; break; }
            currRots[i] = currRot;

        }

        //SequenceEqual(arr2)
        if (currRots.SequenceEqual(Pipe_vals))//(flag == true)
        {
            Debug.Log("WIN");
            Destroy(win_flag);
        }
    }

    void Shuffle()
    {
        
        int[] ang = new int[] { 90, 270, 180, 0 };
        for (int r=0; r< Pipes20.Length-1; r++)
        {
            int a = Random.Range(0, 4);
            Vector3 newRotation = new Vector3(0, 0, ang[a]*1f);
            if (!Pipes20[r].name.Contains("4 (")) Pipes20[r].transform.localEulerAngles += newRotation;
            //Debug.Log("S");
        }
       
    }

}
