using System;
using UnityEngine;
using System.Collections;
public class MoveTo : MonoBehaviour
{
    // Положение точки назначения
    public Transform goal;
    private UnityEngine.AI.NavMeshAgent agent;
    void Start()
    {
        // Получение компонента агента
        agent
            = GetComponent<UnityEngine.AI.NavMeshAgent>();
        // Указаие точки назначения
        agent.destination = goal.position;
    }

    private void Update()
    {
        agent.destination = goal.position;
    }
}