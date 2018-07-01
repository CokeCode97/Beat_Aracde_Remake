using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RGManager : Singleton<RGManager> {

    //============================
    // GameObject
    //============================

    public List<GameObject> note_list = new List<GameObject>();
    public GameObject note_parent;
    public GameObject player;



    //============================
    // Component
    //============================

    public Text text;



    //============================
    // Value
    //============================

    float time, note_time = 1.0f;

    int combo = 0;

    public float judge_standard; // 판정범위를 결정하는 값 1보다 커야함






    //============================
    // Update
    //============================

    void Update() {
        time += Time.deltaTime;

        if (time > note_time) {
            time = 0;
            Make_Note();
            note_time = Random.Range(0.1f, 2.5f);
        }
    }



    //============================
    // Input handling
    //============================

    public void Btn_Hit() {
        if (note_list.Count > 0) {
            note_list[0].SendMessage("Judge");
        }
    }



    //============================
    // Note Management
    //============================

    void Make_Note() {
        ObjectPool.access.Pop("note", note_parent.transform).SendMessage("Init", judge_standard);
    }


    public void Note_Judge(GameObject note, float scale) 
    {

        int judge_value = (int)(Mathf.Abs(scale - 5) * judge_standard);

        bool note_destroy = true;

        if(judge_value < 5)
        {
            if(judge_value == 0)
            {
                text.text = "PERFECT";
            }
            else if(judge_value == 1)
            {
                text.text = "GOOD";
            }
            else if(judge_value == 2)
            {
                text.text = "COOL";
            }
            else if(judge_value == 3)
            {
                text.text = "SOSO";
            }
            else
            {
                text.text = "BAD";
            }

            combo++;
            if (combo % 5 == 0)
            {
                print(combo + "콤보달성");
            }
        }
        else if(judge_value <= 5*judge_standard)
        {
            text.text = "MISS";
            combo = 0;
        }
        else
        {
            note_destroy = false;
        }

        if(note_destroy) {
            note.SendMessage("Note_Destroy");
        }
    }


}
