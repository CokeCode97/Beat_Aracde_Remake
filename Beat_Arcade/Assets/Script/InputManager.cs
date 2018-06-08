using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 touch_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Ray2D touch_ray = new Ray2D(touch_position, Vector2.zero);
                RaycastHit2D[] touch_hit = Physics2D.RaycastAll(touch_ray.origin, touch_ray.direction);

                for (int i = 0; i < touch_hit.Length; i++)
                {
                    if(touch_hit[i].transform.gameObject.CompareTag("Button"))
                    {
                        GamePlayManager.note_list[0].BroadcastMessage("Click");
                    }    
                }
            }
        }
	}


}
