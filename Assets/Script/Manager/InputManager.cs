using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour {

	void Start () {
		
	}

	void Update () {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            RGManager.access.Btn_Hit();
        }
	}

    public void RGButton()
    {
        RGManager.access.Btn_Hit();
    }


}
