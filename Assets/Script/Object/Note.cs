using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Note : MonoBehaviour {

    private List<GameObject> judge_list = new List<GameObject>();
    public float note_speed = 0.5f;
    int note_num = 0;
    Vector3 note_vector3 = new Vector3();



    void Init(int note_num_f) {
        this.note_num = note_num_f;
        this.transform.position = new Vector2((-8.065f + note_num * 1.625f), 5);
        note_vector3.Set(0, -note_speed, 0);
        RGManager.access.note_list[note_num].Add(gameObject);

    }


    void Update() {
        transform.Translate(note_vector3);
    }



    //============================
    // Note Management
    //============================

    void Note_Destroy() {
        RGManager.access.note_list[note_num].Remove(gameObject);
        ObjectPool.access.Push("note", gameObject);
    }


    void Judge() {
        if (judge_list.Count > 0) {
            RGManager.access.Note_Judge(gameObject, judge_list.Count);
        }
    }



    //============================
    // Collision handling
    //============================

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.transform.CompareTag("Judge")) {
            judge_list.Add(collision.gameObject);
        }

        if (collision.transform.CompareTag("MissJudge")) {
            RGManager.access.Note_Judge(gameObject, 0);
        }
    }


    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.transform.CompareTag("Judge")) {
            judge_list.Remove(collision.gameObject);
        }
    }
}
