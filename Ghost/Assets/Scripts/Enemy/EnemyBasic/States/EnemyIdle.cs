using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyIdle : MonoBehaviour
{
    NavMeshAgent agent;
    private Transform EnemyTransform;
    private Transform Player;
    private float distance;
    private StateMachine StateMach;
    [SerializeField] private float PersecutionDistance;

    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        StateMach = GetComponent<StateMachine>();
        Player = GameObject.FindWithTag("Player").transform;
        EnemyTransform = GetComponent<Transform>();

        //agent.speed = 0f;
    }


    void Update()
    {
        Distance();
    }

    private void Distance()
    {

        if (Player != null && EnemyTransform != null)
        {
            // Calcula la distancia entre el player y el enemigo.
            distance = Vector3.Distance(Player.position, EnemyTransform.position);

        }

        if (distance < PersecutionDistance)
        {

            StateMach.ActivateState(StateMach.stateArray[1]);
        }
    }
}
