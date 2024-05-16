using Pathfinding;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float minWalkDist;
    [SerializeField] private float maxWalkDist;

    [SerializeField] private float reachPointDist;

    [SerializeField] private GameObject roamTarget;

    [SerializeField] private float targetFolRange;
    //[SerializeField] private EnemyAttack enemyAttack;
    int attackRange = 10;

    [SerializeField] private float stopTargetRange;

    [SerializeField] private AIDestinationSetter aiDist;

    [SerializeField] AILerp ailerp;

    private Player player;

    public EnemyStates currState;

    private Vector3 roamPos;

    public int health;
    int slojnost;


    public bool boss;

    private void Start()
    {
        player=FindObjectOfType<Player>();
        currState = EnemyStates.Roaming;
        roamPos = GenerateRoamPos();

        slojnost = PlayerPrefs.GetInt("LevelDif");


        if (!boss)  //prosto vrag 
        {
            switch (slojnost)
            {
                case 0:
                    health = 50;
                    break;

                case 1:
                    health = 80;
                    break;

                case 2:
                    health = 120;
                    break;

            }
        }
        else //boss
        {
            switch (slojnost)
            {
                case 0:
                    health = 150;
                    break;

                case 1:
                    health = 200;
                    break;

                case 2:
                    health = 260;
                    break;

            }
        }
    }

    private void Update()
    {

        if (health <= 0)
            currState = EnemyStates.Dead;
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
               
                

                if (Vector3.Distance(gameObject.transform.position, player.transform.position) < attackRange)
                {
                    currState = EnemyStates.Attack;
                }

                if (Vector3.Distance(gameObject.transform.position, player.transform.position) < stopTargetRange)
                {
                    currState = EnemyStates.Roaming;
                    ailerp.speed = 1f;
                }
                break;

            case EnemyStates.Attack:
                if (Vector3.Distance(gameObject.transform.position, player.transform.position) > attackRange)
                {
                    currState = EnemyStates.Following;
                }
                break;

            case EnemyStates.Dead:
                StartCoroutine(Death());
;               break;
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
            ailerp.speed = 1.5f;
        }
    }

    IEnumerator Death()
    {
        if (boss) PlayerPrefs.SetInt("Boss_Dead", 1);
        else
        {
            int vragovUbito = PlayerPrefs.GetInt("Enemy_Dead");
            PlayerPrefs.SetInt("Enemy_Dead", vragovUbito+1);
        }
        Destroy(this.gameObject);
        yield return new WaitForSeconds(4f);
    }

}


public enum EnemyStates
{
    Roaming,
    Following,
    Attack,
    Dead
}