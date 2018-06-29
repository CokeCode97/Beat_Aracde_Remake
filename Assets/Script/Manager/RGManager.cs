using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RGManager : Singleton<RGManager> {

    public List<GameObject> note_list = new List<GameObject>();
    public GameObject note_parent;
    public GameObject player;
    public Text text;

    float time, note_time = 1.0f;

    int combo = 0;


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
        ObjectPool.access.Pop("note", note_parent.transform).SendMessage("Init");
    }


    public void Note_Judge(GameObject note, int judge_point) {
        bool note_destroy = true;
        switch (judge_point) {
            case 0 :
                text.text = "PERFECT";
                break;
            case 1:
                text.text = "GOOD";
                break;
            case 2:
                text.text = "COOL";
                break;
            case 3:
                text.text = "SOSO";
                break;
            case 4:
                text.text = "BAD";
                break;
            case 5:
            case 6:
                text.text = "MISS";
                break;
            default :
                note_destroy = false;
                break;
        }

        if(judge_point < 5) {
            combo++;
            if (combo % 5 == 0) {
                GManager.access.Object_Move(player, new Vector2(10,0));
            }
        }
        else if (judge_point == 5 || judge_point == 6){
            combo = 0;
        }

        if(note_destroy) {
            note.SendMessage("Note_Destroy");
        }
    }


}
