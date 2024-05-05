using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float minWalkDist;
    [SerializeField] private float maxWalkDist;

    [SerializeField] private float reachPointDist;

    [SerializeField] private GameObject roamTarget;

    [SerializeField] private float targetFolRange;
    [SerializeField] private EnemyAttack enemyAttack;

    [SerializeField] private float stopTargetRange;

    [SerializeField] private AIDestinationSetter aiDist;

    private Player player;

    public EnemyStates currState;

    private Vector3 roamPos;

    private void Start()
    {
        player=FindObjectOfType<Player>();
        currState = EnemyStates.Roaming;
        roamPos = GenerateRoamPos();
    }

    private void Update()
    {
        switch (currState)
        {
            case EnemyStates.Roaming:

                roamTarget.transform.position = roamPos;

                if (Vector3.Distance(gameObject.transform.position, roamPos)<=reachPointDist)
                {
                    roamPos=GenerateRoamPos();
                }

                aiDist.target = roamTarget.transform;

                TryFindTarget();
                break;


            case EnemyStates.Following:

                aiDist.target = player.transform;

                if (Vector3.Distance(gameObject.transform.position, player.transform.position) < enemyAttack.attackRange)
                {
                    enemyAttack.TryAttackPlayer();
                }

                if (Vector3.Distance(gameObject.transform.position, player.transform.position) < stopTargetRange)
                {
                    currState = EnemyStates.Roaming;
                }
                break;
        }
    }



    private Vector3 GenerateRoamPos()
    {
        var roamPos = gameObject.transform.position + GenerateRandomDir() * GenerateRandomWalkDist();
        return roamPos;
    }


    private float GenerateRandomWalkDist()
    {
        var randDist = Random.Range(minWalkDist, maxWalkDist);
        return randDist;
    }


    private Vector3 GenerateRandomDir()
    {
        var newDir = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
        return newDir.normalized;
    }


    private void TryFindTarget()
    {
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) <= targetFolRange)
        {
            currState=EnemyStates.Following;
        }
    }


}

public enum EnemyStates
{
    Roaming,
    Following
}