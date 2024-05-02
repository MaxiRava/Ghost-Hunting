using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject panelTutorial;
    [SerializeField] private GameObject gun;

    [SerializeField] private Texts textTutorial;
   
    void Start()
    {
        
    }

    
    void Update()
    {
        if (textTutorial.isGunActive)
        {
            gun.SetActive(true);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            panelTutorial.SetActive(true);

        }
    }
 
}
