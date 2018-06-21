using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour {

	void Start () {
		
	}

	void Update () {
        
	}

    public void RGButton()
    {
        RGManager.access.Btn_Hit();
    }


}
