using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looking : MonoBehaviour
{

    [Header("Direction")]
    public string direction;

    void Update()
    {
        CharacterView();
    }

    private void CharacterView()
    {
        //float MoveX = Input.GetAxis("Horizontal");
        //float MoveY = Input.GetAxis("Vertical");

        if (Input.GetKeyDown("left"))
        {
            direction = "Left";

        }
        else if (Input.GetKeyDown("right"))
        {
            direction = "Right";

        }
        if (Input.GetKeyDown("down"))
        {
            direction = "Down";

        }
        else if (Input.GetKeyDown("up"))
        {
            direction = "Up";
        }
    }
}
