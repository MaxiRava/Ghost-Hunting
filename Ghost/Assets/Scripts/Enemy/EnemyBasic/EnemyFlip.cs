using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlip : MonoBehaviour
{
    [SerializeField] private Transform player;
    private bool isFacingRight = true;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        bool isPlayerRight = transform.position.x < player.transform.position.x;
        Flip(isPlayerRight);
    }

    private void Flip(bool isPlayerRight){

        if ((isFacingRight && !isPlayerRight) || (!isFacingRight && isPlayerRight)){

            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
