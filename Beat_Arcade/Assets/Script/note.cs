using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events; 

public class note : MonoBehaviour {
    private List<GameObject> judge_list = new List<GameObject>();
    public float note_speed = 0.5f;
    int note_num = 0;
	// Use this for initialization
	void Start () {
        Init();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, -note_speed, 0);
	}

    void Init()
    {
        RGManager.Add_Note(gameObject, note_num);
    }



    void Judge()
    {
        if(judge_list.Count > 0)
        {
            print("hit");
            RGManager.Remove_Note(gameObject, note_num);
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Judge"))
        {
            judge_list.Add(collision.gameObject);
        }
    }
}
