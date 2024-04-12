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

    private Animator attackPlayerAnimator;
    private bool isAttacking;
    private float keyAnimator;

    void Start()
    {
        Looking = GetComponent<Looking>();
        attackPlayerAnimator = GetComponent<Animator>();
        isAttacking = false;
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
            
        }

        if (Input.GetKeyUp(Key))
        {
            DisableGun();
            isAttacking = false;

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

