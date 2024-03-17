using System;
using UnityEngine;
using System.Collections;
public class MoveTo : MonoBehaviour
{
    public Transform goal;
    public Transform enemy;
    public float radius;
    private UnityEngine.AI.NavMeshAgent agent;
    void Start()
    {
       agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        if ((enemy.position-goal.position).magnitude<radius)
        {
            agent.destination = goal.position;
        }
    }

    private void Update()
    {
        if ((enemy.position-goal.position).magnitude<radius)
        {
            agent.destination = goal.position;
        }
    }
}