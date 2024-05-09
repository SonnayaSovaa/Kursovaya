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
       Destination();
    }

    private void Update()
    {
        Destination();
    }

    private void Destination()
    {
        if ((enemy.position-goal.position).magnitude<radius)
        {
            agent.destination = goal.position;
        }
    }
}