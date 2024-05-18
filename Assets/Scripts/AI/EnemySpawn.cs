using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    [SerializeField] private GameObject enemy1;

    [SerializeField] private int minX;
    [SerializeField] private int maxX;
    [SerializeField] private int minY;
    [SerializeField] private int maxY;

    [SerializeField] private float hight;

    public int vragov_ubito=0;

    public int number1;

    private void Awake()
    {
        int LevelDif = PlayerPrefs.GetInt("LevelDif");
        
        if (LevelDif == 0) number1 = 25;
        else if (LevelDif == 1) number1 = 30;
        else number1 = 40;
        
        

        for (int i=0; i<number1; i++)
        {
            Spawn(enemy1);
        }
    }


    void Spawn(GameObject enemy)
    {
        var enemyInstamce = Instantiate(enemy);
        var newPos = GenStartPos();
        enemyInstamce.transform.position=newPos;
    }


    private Vector3 GenStartPos()
    {
        var strtPos = new Vector3(Random.Range(minX, maxX), hight, Random.Range(minY, maxY));
        return strtPos;
    }

}
