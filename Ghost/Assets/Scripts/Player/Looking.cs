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
        float MoveX = Input.GetAxis("Horizontal");
        float MoveY = Input.GetAxis("Vertical");

        if (MoveX < 0)
        {
            direction = "Left";

        }
        else if (MoveX > 0)
        {
            direction = "Right";

        }
        if (MoveY < 0)
        {
            direction = "Down";

        }
        else if (MoveY > 0)
        {
            direction = "Up";
        }
    }
}
