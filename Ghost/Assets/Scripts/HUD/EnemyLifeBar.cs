using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLifeBar : MonoBehaviour
{
    [SerializeField] private Image barImage;

    public void UpdateHealthbar(float maxHealth, float health){

        barImage.fillAmount = health / maxHealth;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
