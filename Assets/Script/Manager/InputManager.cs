using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour {

	void Start () {
		
	}

	void Update () {
        
	}

    public void RT_Button(int num)
    {
        RGManager.access.Btn_Hit(num);
    }


}
