using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField] private GameObject doorClose;
    [SerializeField] private GameObject doorOpen;

    [SerializeField] private int enemiesAmount;
    [SerializeField] private int enemiesEliminated;

    void Start()
    {
        enemiesAmount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    public void EnemiesEliminates()
    {

        enemiesEliminated += 1;

        if (enemiesEliminated == enemiesAmount)
        {
            doorClose.SetActive(false);
            doorOpen.SetActive(true);

        }
    }

    void Update()
    {

    }

}
