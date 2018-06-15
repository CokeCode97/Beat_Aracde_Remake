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

	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, -note_speed, 0);
	}

    void Init(int note_num_f)
    {
        this.note_num = note_num_f;
        this.transform.position = new Vector2((-8.065f + note_num * 1.625f), 5);
        RGManager.Add_Note(gameObject, note_num);
    }

    void Note_Destroy()
    {
        RGManager.Remove_Note(gameObject, note_num);
        ObjectPool.instance.Push(gameObject, "note");
    }

    void Judge()
    {
        switch(judge_list.Count)
        {
            case 1 :
                print("BAD");
                break;
            case 2:
                print("SOSO");
                break;
            case 3:
                print("COOL");
                break;
            case 4:
                print("GOOD");
                break;
            case 5:
                print("PERFECT");
                break;
            default :
                break;
        }

        if(judge_list.Count > 0)
        {
            Note_Destroy();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Judge"))
        {
            judge_list.Add(collision.gameObject);
        }

        if(collision.transform.CompareTag("MissJudge"))
        {
            //print("MISS");
            Note_Destroy();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Judge"))
        {
            judge_list.Remove(collision.gameObject);
        }
    }
}
