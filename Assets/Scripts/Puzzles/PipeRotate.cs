using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class PipeRotate : MonoBehaviour
{
    Transform[] Pipes;
    GameObject[] Pipes20 = new GameObject[68];
    int[] Pipe_vals = new int[68];


    public ActionBasedController controller_L;
    public ActionBasedController controller_R;

    [SerializeField] private Image tablo1;
    [SerializeField] private Image tablo2;

    int[] currRots = new int[68];

    [SerializeField] private AudioClip access;
    [SerializeField] private AudioSource main;

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
        for (int i = 0; i < Pipes20.Length; i++)
        {
            int currRot = System.Convert.ToInt32(Pipes20[i].transform.localEulerAngles.z);

            if (Pipes20[i].name.Contains("1 (")) currRot = Mathf.Abs(currRot) % 180;
            currRots[i] = currRot;
        }

        if  (currRots.SequenceEqual(Pipe_vals))
        {
            //Debug.Log("WIN");
            tablo1.color = new Color(191/255f,1f,186/255f,1f);
            tablo2.color = new Color(191 / 255f, 1f, 186 / 255f, 1f);

            //tablo1.color= new Color(191, 255, 186, 255);
            main.PlayOneShot(access);

            SetInt("PipeRotat", 1);

            Destroy(this);
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

    public void SetInt(string KeyName, int Value)
    {
        PlayerPrefs.SetInt(KeyName, Value);
    }


}
