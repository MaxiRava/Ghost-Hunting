using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGun : MonoBehaviour
{
    private KeyCode Key;
    public LineRenderer line;
    public Transform gun;
    [SerializeField] private GameObject gunImage;
    [SerializeField] private float laserRange;
    [SerializeField] private LayerMask layerObstacule;

    [SerializeField] private float gunDamage;

    public bool damageActive;

    private Looking Looking;

    private Animator attackPlayerAnimator;
    public bool isAttacking;
    private float keyAnimator;

    //private Transform Enemy;
    private bool isEnemyNear;

    private int enemiesInsideTrigger;

    void Start()
    {
        Looking = GetComponent<Looking>();
        attackPlayerAnimator = GetComponent<Animator>();
        isAttacking = false;
        damageActive = false;
        isEnemyNear = false;
        enemiesInsideTrigger = 0;

        //Enemy = GameObject.FindWithTag("Enemy").transform;
    }

    private void Update()
    {

        KeyInput();

        attackPlayerAnimator.SetFloat("keyDirection", keyAnimator);

        if (Input.GetKey(Key))
        {
            EneableGun();
            UpdateGun();
            isAttacking = true;
            gunImage.SetActive(true);

        }

        if (Input.GetKeyUp(Key))
        {
            DisableGun();
            isAttacking = false;
            gunImage.SetActive(false);
            damageActive = false;

        }

        attackPlayerAnimator.SetBool("isAttacking", isAttacking);

    }

    private void KeyInput()
    {
        switch (Looking.direction)
        {
            case "Up":

                Key = KeyCode.UpArrow;
                keyAnimator = 0f;


                break;

            case "Down":

                Key = KeyCode.DownArrow;
                keyAnimator = 0.33f;

                break;

            case "Left":

                Key = KeyCode.LeftArrow;
                keyAnimator = 0.66f;

                break;

            case "Right":

                Key = KeyCode.RightArrow;
                keyAnimator = 1f;

                break;

            default:
                break;
        }

    }

    private void EneableGun()
    {

        line.enabled = true;
    }

    private void UpdateGun()
    {
        //Vector3 rayOffset = ;
        Vector3 rayOrigin = gun.position + gun.right * 0.1f;

        line.SetPosition(0, rayOrigin);

        line.SetPosition(1, rayOrigin + gun.up * laserRange);

        //Debug.Log(isEnemyNear);

        //RaycastHit2D hit = Physics2D.Raycast(gun.position - gun.up, -gun.up, laserRange, layerObstacule);

        // if (hit.collider != null)
        // {
        //     line.SetPosition(1, hit.point);

        //     damageActive = true;
        //     hit.collider.GetComponent<EnemyTakeDamage>().EnemyGetDamage(gunDamage);

        //     //Debug.Log("daño activado");
        // }
        // else
        // {
        //     damageActive = false;
        //     //Debug.Log("daño desactivado");
        // }

        if (isEnemyNear)
        {
            
            Transform nearestEnemy = FindNearestEnemy();
            
            float distance = Vector3.Distance(gun.position, nearestEnemy.transform.position);
            RaycastHit2D hit = Physics2D.Raycast(gun.position, nearestEnemy.transform.position, distance, layerObstacule);

            if (nearestEnemy != null)
            {
                line.SetPosition(1, nearestEnemy.position);
                damageActive = true;
                nearestEnemy.GetComponent<EnemyTakeDamage>().EnemyGetDamage(gunDamage);
            }

            if (hit.collider == null)
            {
                damageActive = false;
            }



            // //line.SetPosition(1, Enemy.position);

            // damageActive = true;
            // hit.collider.GetComponent<EnemyTakeDamage>().EnemyGetDamage(gunDamage);

            // //Debug.Log("daño activado");
        }
   

    }

    private Transform FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Transform nearestEnemy = null;
        float minDistance = Mathf.Infinity;
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(gun.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestEnemy = enemy.transform;
            }
        }
        return nearestEnemy;
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.CompareTag("Enemy"))
        {
            enemiesInsideTrigger++;
            if (!isEnemyNear)
            {
                isEnemyNear = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D trigger)
    {
        if (trigger.gameObject.CompareTag("Enemy"))
        {
            enemiesInsideTrigger--;
            if (enemiesInsideTrigger <= 0)
            {
                isEnemyNear = false;
            }
        }
    }

    private void DisableGun()
    {

        line.enabled = false;
    }

}

