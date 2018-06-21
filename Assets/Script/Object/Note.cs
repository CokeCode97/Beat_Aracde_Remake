using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Note : MonoBehaviour {
    RectTransform rect_transform;

    Vector2 position_vector = new Vector2(-900, -350);
    Vector2 scale_vector = new Vector2();

    float scale_x;
    float scale_y;

    [SerializeField]
    float note_speed;
    float first_scale;


    //============================
    // Init
    //============================

    void Awake() {
        rect_transform = GetComponent<RectTransform>();
    }


    void Init() {
        rect_transform.localPosition = position_vector;

        scale_vector.Set(first_scale, first_scale);
        rect_transform.localScale = scale_vector;

        RGManager.access.note_list.Add(gameObject);
    }



    //============================
    // Update
    //============================

    void Update() {
        scale_x = rect_transform.localScale.x;

        if (scale_x > 2.5) {
            scale_y = rect_transform.localScale.y;
            float speed = note_speed * Time.deltaTime;

            scale_vector.Set(scale_x - speed, scale_y - speed);
            rect_transform.localScale = scale_vector;
        }
        else {
            RGManager.access.Note_Judge(gameObject, 5);
        }
    }



    //============================
    // Note Management
    //============================

    void Note_Destroy() {
        RGManager.access.note_list.Remove(gameObject);
        ObjectPool.access.Push("note", gameObject);
    }


    void Judge() {
        int judge_value = (int)(Mathf.Abs(scale_x - 5)*2);
        RGManager.access.Note_Judge(gameObject, judge_value);
    }
}
