using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaFloor : MonoBehaviour
{
    [SerializeField] Transform movingpoint;
    Enemy enemy;
    bool flag = true;
    private void Update()
    {
        if (enemy.boss_umer && flag)
        {
            StartCoroutine(moveObject());
            flag = false;
        }
    }

    private void Start()
    {
        enemy = FindObjectOfType<Enemy>();
    }
    public IEnumerator moveObject()
    {
        float totalMovementTime = 30f; //the amount of time you want the movement to take
        float currentMovementTime = 0f;//The amount of time that has passed
        while (Vector3.Distance(transform.localPosition, movingpoint.position) > 0)
        {
            currentMovementTime += Time.deltaTime;
            transform.localPosition = Vector3.Lerp(this.gameObject.transform.position, movingpoint.position, currentMovementTime / totalMovementTime);
            yield return null;
        }
    }

}
