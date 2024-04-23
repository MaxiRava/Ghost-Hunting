using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float timeBetweenShoots;
    [SerializeField] private Transform spotShoot;

    
    private Transform EnemyTransform;
    private Transform Player;
    private float distance;
    private StateMachine StateMach;
    [SerializeField] private float PersecutionDistance;

    void OnEnable()
    {
        StateMach = GetComponent<StateMachine>();
        Player = GameObject.FindWithTag("Player").transform;
        EnemyTransform = GetComponent<Transform>();

        StartCoroutine(Shoot());
    }

    void Update()
    {
        Distance();
        
        if (projectilePrefab)
        {
            
        }
    }

    IEnumerator Shoot()
    {

        while (true)
        {

            yield return new WaitForSeconds(timeBetweenShoots);
            Instantiate(projectilePrefab, spotShoot.position, Quaternion.identity);

        }

    }

    private void Distance()
    {

        if (Player != null && EnemyTransform != null)
        {
            // Calcula la distancia entre el player y el enemigo.
            distance = Vector3.Distance(Player.position, EnemyTransform.position);

        }

        if (distance > PersecutionDistance)
        {
            Debug.Log("no te muevas");
            
            StopAllCoroutines();
            StateMach.ActivateState(StateMach.stateArray[0]);


        }

    }
}
