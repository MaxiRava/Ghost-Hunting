using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform MeleeController;

    private Looking Looking;

    
    void Start()
    {
        Looking = GetComponent<Looking>();
    }


    void Update()
    {
        ChangePosition();
    }

    private void ChangePosition()
    {
        switch (Looking.direction)
        {
            case "Up":

                MeleeController.position = transform.position + new Vector3(-0.05f, 0.75f, 0f);

                MeleeController.rotation = transform.rotation * Quaternion.Euler(new Vector3(0f, 0f, 0f));

                break;

            case "Down":

                MeleeController.position = transform.position + new Vector3(-0.05f, -0.75f, 0f);

                MeleeController.rotation = transform.rotation * Quaternion.Euler(new Vector3(0f, 0f, 180f));

                break;

            case "Left":

                MeleeController.position = transform.position + new Vector3(-0.6f, -0.2f, 0f);

                MeleeController.rotation = transform.rotation * Quaternion.Euler(new Vector3(0f, 0f, 90f));

                break;

            case "Right":

                MeleeController.position = transform.position + new Vector3(0.6f, -0.2f, 0f);

                MeleeController.rotation = transform.rotation * Quaternion.Euler(new Vector3(0f, 0f, -90f));

                break;

            default:
                break;
        }
    }
}
