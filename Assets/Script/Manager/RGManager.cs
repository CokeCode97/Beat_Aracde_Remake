using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RGManager : Singleton<RGManager> {

    public List<GameObject> note_list = new List<GameObject>();
    public GameObject note_parent;
    public Text text;

    float time, note_time = 1.0f;


    void Update() {
        time += Time.deltaTime;

        if (time > note_time) {
            time = 0;
            Make_Note();
            note_time = Random.Range(0.1f, 1.0f);
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
                print("GOOD");
                break;
            case 2:
                text.text = "COOL";
                print("COOL");
                break;
            case 3:
                text.text = "SOSO";
                print("SOSO");
                break;
            case 4:
                text.text = "BAD";
                print("BAD");
                break;
            case 5:
            case 6:
            case 7:
                text.text = "MISS";
                print("MISS");
                break;
            default :
                note_destroy = false;
                break;
        }

        if(note_destroy) {
            note.SendMessage("Note_Destroy");
        }
    }


}
