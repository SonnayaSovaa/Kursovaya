using System;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;


public class MagicCube : MonoBehaviour
{

    public GameObject[] points = new GameObject[9];
    int[] vals = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    [SerializeField] private Image tablo1;
    [SerializeField] private Image tablo2;

    [SerializeField] private AudioClip access;
    [SerializeField] private AudioSource main;

    Player player;

    int score;
    public int keyscore;

    int slojnost;


    private void Update()
    {
        Check();
    }

    private void Start()
    {
        
        slojnost = PlayerPrefs.GetInt("LevelDif");
        player = FindObjectOfType<Player>();

        switch (slojnost)
        {
            case 0:
                keyscore = 4;
                score = 250;
                break;

            case 1:
                keyscore = 2;
                score = 200;
                break;

            case 2:
                keyscore = 0;
                score = 150;
                break;

        }
    }



    private void Check()
    {
        int was = 0;

        foreach (GameObject point in points)
        {
            Transform[] childs = point.GetComponentsInChildren<Transform>();
            foreach (Transform chil in childs)
                if (childs.Length != 0 && !(chil.name.Contains("Right")|| chil.name.Contains("Left")) &&chil.name.Contains("Attach")) //
                {
                    int a = Convert.ToInt32(Convert.ToString(chil.name[1]));

                    vals[a - 1] = Convert.ToInt32(point.name);
                    was++;
                    break;
                }

            //Debug.Log("WAS   " + point.GetComponentInParent<Transform>().name);
        }


        bool hor = false, ver = false, dia = false;


        if (was == 9)
        {
            hor = (vals[0] + vals[1] + vals[2] == vals[3] + vals[4] + vals[5] && vals[6] + vals[7] + vals[8] == vals[0] + vals[1] + vals[2]);
            ver = (vals[0] + vals[3] + vals[6] == vals[1] + vals[4] + vals[7] && vals[0] + vals[3] + vals[6] == vals[2] + vals[5] + vals[8]);
            dia = (vals[0] + vals[8] == vals[2] + vals[6]);

            //Debug.Log("HOR   " + hor);
            //Debug.Log("VER   " + ver);
            //Debug.Log("DIA   " + dia);

            if (hor && ver && dia && vals[0] != 0 && vals[1] != 0 && vals[2] != 0 && vals[3] != 0 && vals[4] != 0 && vals[5] != 0 && vals[6] != 0 && vals[7] != 0 && vals[8] != 0)
            {
                Win(score);
            }

           
        }

    }

    public void Win(int up)
    {
        player.ScoreUp(up);

        tablo1.color = new Color(191 / 255f, 1f, 186 / 255f, 1f);
        tablo2.color = new Color(191 / 255f, 1f, 186 / 255f, 1f);

        //tablo1.color= new Color(191, 255, 186, 255);
        main.PlayOneShot(access);
        PlayerPrefs.SetInt("MagicCube", 1);
        Destroy(this);
    }







}
