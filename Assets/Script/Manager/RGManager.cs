using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGManager : Singleton<RGManager> {
    public List<GameObject>[] note_list;
    public GameObject note;
    float time;

    // Use this for initialization
    void Awake() {
        note_list = new List<GameObject>[3];
        note_list[0] = new List<GameObject>();
        note_list[1] = new List<GameObject>();
        note_list[2] = new List<GameObject>();
    }


    // Update is called once per frame
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

    public void Btn_Hit(int num) {
        if (note_list[num][0] != null) {
            note_list[num][0].SendMessage("Judge");
        }
    }



    //============================
    // Note Management
    //============================

    void Make_Note() {
        int num = (int)Random.Range(0, 1);
        ObjectPool.access.Pop("note").SendMessage("Init", num);
    }


    public void Note_Judge(GameObject note, int judge_point) {
        switch (judge_point) {
            case 0:
                print("MISS");
                break;
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

        note.SendMessage("Note_Destroy");
    }


}
