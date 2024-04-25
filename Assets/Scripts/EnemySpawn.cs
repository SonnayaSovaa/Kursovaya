using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    [SerializeField] private GameObject enemy1;
    [SerializeField] private GameObject enemy2;

    [SerializeField] private int minX;
    [SerializeField] private int maxX;
    [SerializeField] private int minY;
    [SerializeField] private int maxY;

    [SerializeField] private float hight;

    [SerializeField] private int number1;
    [SerializeField] private int number2;

    private void Start()
    {
        for (int i=0; i<number1; i++)
        {
            Spawn(enemy1);
        }

        for (int i = 0; i < number2; i++)
        {
            Spawn(enemy2);
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