using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AGMAnager : Singleton<AGMAnager> {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Attack(GameObject player, int combo) {
        player.BroadcastMessage("Attack", combo);
    }
}
