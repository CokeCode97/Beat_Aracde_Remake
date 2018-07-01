using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Note : MonoBehaviour {
    RectTransform rect_transform;

    Vector2 position_vector = new Vector2(-900, -350);
    Vector2 scale_vector = new Vector2();

    public float note_speed;
    public float first_scale;

    float scale_x;
    float scale_y;

    float miss_point;



    //============================
    // Init
    //============================

    void Awake() {
        rect_transform = GetComponent<RectTransform>();
    }


    void Init(float judge_standart) {
        rect_transform.localPosition = position_vector;

        scale_vector.Set(first_scale, first_scale);
        rect_transform.localScale = scale_vector;

        miss_point = -2.5f + (2.5f * judge_standart);

        RGManager.access.note_list.Add(gameObject);
    }



    //============================
    // Update
    //============================

    void Update() {
        scale_x = rect_transform.localScale.x;

        if (scale_x > miss_point) {
            scale_y = rect_transform.localScale.y;
            float speed = note_speed * Time.deltaTime;

            scale_vector.Set(scale_x - speed, scale_y - speed);
            rect_transform.localScale = scale_vector;
        }
        else {
            RGManager.access.Note_Judge(gameObject, 0);
        }
    }



    //============================
    // Note Management
    //============================

    void Note_Destroy() 
    {
        RGManager.access.note_list.Remove(gameObject);
        ObjectPool.access.Push("note", gameObject);
    }


    void Judge() 
    {
        RGManager.access.Note_Judge(gameObject, scale_x);
    }
}
