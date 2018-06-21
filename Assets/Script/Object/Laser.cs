using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
    Animator animator;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void Init(Direction direction) {
        transform.eulerAngles = new Vector3(0, (int)direction, 0);
        transform.localPosition = new Vector3(0, 0, 0);
        transform.Translate(2.2f, 0, 0);
    }

    private void Des() {
        Destroy(gameObject);
    }
}
