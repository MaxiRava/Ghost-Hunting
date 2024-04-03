using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGun : MonoBehaviour
{
    private KeyCode Key = KeyCode.E;
    public LineRenderer line;
    public Transform gun;
    private float laserRange = 1.5f;
    [SerializeField] private LayerMask layerObstacule;

    public bool damageActive = false;

    void Start()
    {

    }

    private void Update()
    {

        // if (Input.GetKeyDown("left"))
        // {
        //     EneableGun();
        // }

        if (Input.GetKeyDown(Key))
        {
            EneableGun();
        }

        if (Input.GetKey(Key))
        {
            UpdateGun();
        }

        if (Input.GetKeyUp(Key))
        {
            DisableGun();
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
        // line.SetPosition(0, (Vector2)gun.position + (-(Vector2)gun.up) * (colliderBroad / 2));
        // line.SetPosition(1, (Vector2)gun.position + (-(Vector2)gun.up) * (laserRange));

        RaycastHit2D hit = Physics2D.Raycast(gun.position - gun.up, -gun.up, laserRange, layerObstacule);

        if (hit.collider != null)
        {
            line.SetPosition(1, hit.point);
            damageActive = true;
            Debug.Log("daño activado");
        }
        else
        {
            damageActive = false;
            Debug.Log("daño desactivado");
        }

    }

    private void DisableGun()
    {

        line.enabled = false;
    }

}
