using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PipeRotate : MonoBehaviour
{
    Transform[] Pipes;
    public GameObject[] Pipes20 = new GameObject[68];
    int[] Pipe_vals = new int[68];


    public ActionBasedController controller_L;
    public ActionBasedController controller_R;

    [SerializeField] private GameObject win_flag;

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
            Pipe_vals[a] =System.Convert.ToInt32( pipe.transform.eulerAngles.z);
            a++;
        }

        Shuffle();
    }

    private void Update()
    {
        Debug.Log(Pipe_vals);
        
    }

    private void Check()
    {
        bool flag = true;
        for (int i = 0; i < Pipes20.Length - 1; i++)
        {
            if ((Pipes20[i].name.Contains("1 (") && ((Mathf.Abs(System.Convert.ToInt32(Pipes20[i].transform.eulerAngles.z)) % 180 != Mathf.Abs(Pipe_vals[i]) % 180))) || System.Convert.ToInt32(Pipes20[i].transform.eulerAngles.z) != Pipe_vals[i])
            { flag = false; break; }

        }
        if (flag == true)
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
            if (!Pipes20[r].name.Contains("4 (")) Pipes20[r].transform.eulerAngles += newRotation;
            //Debug.Log("S");
        }
       
    }

}
