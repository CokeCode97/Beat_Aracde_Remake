using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aa : MonoBehaviour {

    public float move_power = 1f;
    public float jump_power = 1f;

    Rigidbody2D rigid;

    Vector3 movement;
    bool isJumping = false;


	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
        }
	}

    private void FixedUpdate()
    {
        MoveF();
        JumpF();
    }

    void MoveF()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveVelocity = Vector3.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            moveVelocity = Vector3.right;
        }

        transform.position += moveVelocity * move_power * Time.deltaTime;
           
    }

    void JumpF()
    {
        if (!isJumping)
            return;

        rigid.velocity = Vector2.zero;

        Vector2 jumpVelocity = new Vector2(0, jump_power);
        rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);

        isJumping = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        //print("enter");
        collision.SendMessage("Hit", 10);
    }

    private void OnTriggerStay2D(Collider2D collision) {
        //print("stay");
    }

    private void OnTriggerExit2D(Collider2D collision) {
        //print("exit");
    }
}
