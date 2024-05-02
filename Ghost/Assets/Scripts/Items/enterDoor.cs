using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterDoor : MonoBehaviour
{

    [SerializeField] private GameObject doorMark;
    [SerializeField] private GameObject doorPanel;

    private KeyCode Key = KeyCode.E;

    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] private Dialogue dialogue;

       void Start()
    {
        enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(Key))
        {
            doorPanel.SetActive(true);
            playerMovement.StopMovement();
        }

    }

     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && dialogue.doorActive)
        {
            
            doorMark.SetActive(true);
            enabled = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            
            doorMark.SetActive(false);
            enabled = false;

        }
    }
}
