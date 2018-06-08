using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events; 

public class note : MonoBehaviour {
    public float note_speed = 0.5f;
	// Use this for initialization
	void Start () {
        Init();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, -note_speed, 0);
	}

    void Click()
    {
        transform.position = new Vector2(-8.065f, 5f);
    }

    void Init()
    {
        GamePlayManager.note_list.Add(gameObject);
    }
}
