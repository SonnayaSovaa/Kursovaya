using UnityEngine;
using System.Collections;
public class MoveTo : MonoBehaviour
{
    // Положение точки назначения
    public Transform goal;
    void Start()
    {
        // Получение компонента агента
        UnityEngine.AI.NavMeshAgent agent
            = GetComponent<UnityEngine.AI.NavMeshAgent>();
        // Указаие точки назначения
        agent.destination = goal.position;
    }
}