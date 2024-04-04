using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGun : MonoBehaviour
{
    private KeyCode Key;
    public LineRenderer line;
    public Transform gun;
    private float laserRange = 1.5f;
    [SerializeField] private LayerMask layerObstacule;

    [SerializeField] private float gunDamage = 0.1f;

    public bool damageActive = false;

    private Looking Looking;

    void Start()
    {
        Looking = GetComponent<Looking>();
    }

    private void Update()
    {

        if (Looking.direction == "Up")
        {
            Key = KeyCode.UpArrow;
            //Debug.Log("aca cargo");
        }

        if (Looking.direction == "Down")
        {
            Key = KeyCode.DownArrow;
        }

        if (Looking.direction == "Left")
        {
            Key = KeyCode.LeftArrow;
        }

        if (Looking.direction == "Right")
        {
            Key = KeyCode.RightArrow;
        }


        // if (Input.GetKeyDown(Key))
        // {
        //     //EneableGun();

        //     //Debug.Log("aca disparo");
        // }

        if (Input.GetKey(Key))
        {
            EneableGun();
            UpdateGun();
        }

        if (Input.GetKeyUp(Key))
        {
            DisableGun();

            //Debug.Log("aca no disparo");
        }
        

    }

    private void EneableGun()
    {

        line.enabled = true;
    }

    private void UpdateGun()
    {
        line.SetPosition(0, gun.position);

        line.SetPosition(1, gun.position - gun.up * laserRange);

        RaycastHit2D hit = Physics2D.Raycast(gun.position - gun.up, -gun.up, laserRange, layerObstacule);

        if (hit.collider != null)
        {
            line.SetPosition(1, hit.point);

            damageActive = true;
            hit.collider.GetComponent<EnemyTakeDamage>().EnemyGetDamage(gunDamage);

            //Debug.Log("daño activado");
        }
        else
        {
            damageActive = false;
            //Debug.Log("daño desactivado");
        }

    }

    private void DisableGun()
    {

        line.enabled = false;
    }



}
