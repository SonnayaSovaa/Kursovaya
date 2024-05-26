using Pathfinding;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float minWalkDist;
    [SerializeField] private float maxWalkDist;

    [SerializeField] private float reachPointDist;

    [SerializeField] private GameObject roamTarget;

    [SerializeField] private float targetFolRange;
    public float attackRange = 1f;

    [SerializeField] private float stopTargetRange;

    [SerializeField] private AIDestinationSetter aiDist;

    [SerializeField] AIPath aipath;

    [SerializeField] EnemyAnimation anim;

    private Player player;

    public EnemyStates currState;

    private Vector3 roamPos;

    public int health;
    int slojnost;

    int score;

    public bool boss;

    [SerializeField] GameObject key;
    int keySpawn;

    EnemySpawn spawn;

    bool umer=true;

    private void Start()
    {
        spawn=FindObjectOfType<EnemySpawn>();

        keySpawn = Convert.ToInt32(spawn.number1/3-1);
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
                    score = 32;
                    break;

                case 1:
                    health = 80;
                    score = 27;
                    break;

                case 2:
                    health = 120;
                    score = 23;
                    break;

            }
        }
        else //boss
        {
            switch (slojnost)
            {
                case 0:
                    health = 180;
                    score = 150;
                    break;

                case 1:
                    health = 240;
                    score = 200;
                    break;

                case 2:
                    health = 360;
                    score = 225;
                    break;

            }
        }
    }

    private void Update()
    {
        if (health <= 0)
        {
            Death(umer);            
            player.ScoreUp(score);
            aiDist.target = null;            
            anim.IsWalk(false);
            anim.IsRunning(false);
            anim.PlayDead();
            (this.gameObject.GetComponent<AIPath>() as MonoBehaviour).enabled = false;
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
        var randDist = UnityEngine.Random.Range(minWalkDist, maxWalkDist);
        return randDist;
    }


    private Vector3 GenerateRandomDir()
    {
        var newDir = new Vector3(UnityEngine.Random.Range(-1f, 1f), 0f, UnityEngine.Random.Range(-1f, 1f));
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

    void Death(bool cond)
    {
        if (cond)
        {
            if (boss)
            {
                PlayerPrefs.SetInt("Boss_Dead", 1);
            }
            else
            {
                spawn.vragov_ubito++;
                int vragovUbito = PlayerPrefs.GetInt("Enemy_Dead");

                PlayerPrefs.SetInt("Enemy_Dead", vragovUbito + 1);

            }

            GenKey(this.gameObject.transform.position);
            umer = false;
        }
    }


    void GenKey(Vector3 pos)
    {
        Destroy(this.gameObject, 2f);
        if (spawn.vragov_ubito == keySpawn)
        {
            var keyInstamce = Instantiate(key);
            var newPos = pos + new Vector3(0, 1, 0);
            keyInstamce.transform.position = newPos;
        }
        
    }
}


public enum EnemyStates
{
    Roaming,
    Following
}