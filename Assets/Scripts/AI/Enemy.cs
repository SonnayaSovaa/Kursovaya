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
    public float attackRange = 1f;

    [SerializeField] private float stopTargetRange;

    [SerializeField] private AIDestinationSetter aiDist;

    [SerializeField] AIPath aipath;

    //[SerializeField] EnemyAttack attack;
    [SerializeField] EnemyAnimation anim;

    private Player player;

    public EnemyStates currState;

    private Vector3 roamPos;

    public int health;
    int slojnost;


    public bool boss;

    private void Start()
    {
        PlayerPrefs.SetInt("Enemy_Dead", 0);

        player =FindObjectOfType<Player>();
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
                    health = 180;
                    break;

                case 1:
                    health = 240;
                    break;

                case 2:
                    health = 360;
                    break;

            }
        }
    }

    private void Update()
    {

        if (health <= 0)
        {
            aiDist.target = null;
            StartCoroutine(Death());
            anim.IsWalk(false);
            anim.IsRunning(false);
            anim.PlayDead();
        }
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

                anim.IsWalk(true);
                anim.IsRunning(false);

                break;


            case EnemyStates.Following:

                aiDist.target = player.transform;

                anim.IsWalk(false);
                anim.IsRunning(true);
                anim.PlayAttack(false);

                if (Vector3.Distance(gameObject.transform.position, player.transform.position) <= attackRange)
                {
                    //attack.TryAttackPlayer();
                    anim.PlayAttack(true);
                }

                if (Vector3.Distance(gameObject.transform.position, player.transform.position) >= stopTargetRange)
                {
                    currState = EnemyStates.Roaming;
                    aipath.maxSpeed = 1.5f;
                }
                break;
        }
    }



    private Vector3 GenerateRoamPos()
    {
        Vector3 roamPos;
        GraphNode node;
        node = AstarPath.active.GetNearest(gameObject.transform.position + GenerateRandomDir() * GenerateRandomWalkDist()).node;
        while (!node.Walkable)
        {
            node = AstarPath.active.GetNearest(gameObject.transform.position + GenerateRandomDir() * GenerateRandomWalkDist()).node;
        }
        roamPos = (Vector3)node.position;
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
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) < targetFolRange)
        {
            currState=EnemyStates.Following;
            aipath.maxSpeed= 1f;
        }
    }

    IEnumerator Death()
    {
        if (boss)
        {
            PlayerPrefs.SetInt("Boss_Dead", 1);
            yield return new WaitForSeconds(2f);
        }
        else
        {
            int vragovUbito = PlayerPrefs.GetInt("Enemy_Dead");
            PlayerPrefs.SetInt("Enemy_Dead", vragovUbito + 1);
            yield return new WaitForSeconds(2f);
        }
        Destroy(this.gameObject);
       
       
    }

}


public enum EnemyStates
{
    Roaming,
    Following
}