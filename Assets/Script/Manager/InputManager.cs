using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum InputType
{
    non = -1,
    down = 0,
    left = 1,
    right = 2
}

public class InputManager : MonoBehaviour {
    public GameObject player;

    float dt = 0;
    float lt = 0.2f;

    InputType last_input;

	void Start () {
	}


	void Update () {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            RGManager.access.Btn_Hit();
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GManager.access.Object_Move(player, Direction.left);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            GManager.access.Object_Move(player, Direction.right);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GManager.access.Object_Jump(player);
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (last_input.Equals(InputType.left))
            {
                GManager.access.Object_Dash(player);
                last_input = InputType.non;
            }
            else
            {
                last_input = InputType.left;
                dt = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (last_input.Equals(InputType.right))
            {
                GManager.access.Object_Dash(player);
                last_input = InputType.non;
            }
            else
            {
                last_input = InputType.right;
                dt = 0;
            }
        }



        if(!last_input.Equals(InputType.non))
        {
            if(dt < lt)
            {
                dt += Time.deltaTime;
            }
            else
            {
                dt = 0;
                last_input = InputType.non;
            }
        }
	}

    public void RGButton()
    {
        RGManager.access.Btn_Hit();
    }


}
