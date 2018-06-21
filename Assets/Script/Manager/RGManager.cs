using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGManager : Singleton<RGManager> {

    public List<GameObject> note_list = new List<GameObject>();
    public GameObject note_parent;
    float time;


    void Update() {
        time += Time.deltaTime;

        if (time > 2f) {
            time = 0;
            Make_Note();
        }
    }

    //============================
    // Input handling
    //============================

    public void Btn_Hit() {
        if (note_list[0] != null) {
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
        switch (judge_point) {
            case 0 :
                print("PERFECT");
                break;
            case 1:
                print("GOOD");
                break;
            case 2:
                print("COOL");
                break;
            case 3:
                print("SOSO");
                break;
            case 4:
                print("BAD");
                break;
            default :
                print("MISS");
                break;
        }

        note.SendMessage("Note_Destroy");
    }


}
