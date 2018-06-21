using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction {
    right = 0,
    left = 180
}

public class Character : MonoBehaviour {

    Rigidbody2D rigidbody;
    Collider2D collider;
    GameObject character;

    Vector3 angle = new Vector3();
    Vector2 move_vector = new Vector2();
    Vector2 jump_vector = new Vector2();

    Direction direction = Direction.right;

    [SerializeField]
    float speed;
    [SerializeField]
    float jump_power;



	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        character = transform.GetChild(0).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        move_vector.Set(speed * Time.deltaTime, 0);
        jump_vector.Set(0, jump_power);

        if(Input.GetKey(KeyCode.LeftArrow)) {
            transform.Translate(-move_vector);
            direction = Direction.left;
            Change_Direction();
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.Translate(move_vector);
            direction = Direction.right;
            Change_Direction();
        }
        if(Input.GetKeyDown(KeyCode.UpArrow)) {
            rigidbody.AddForce(jump_vector, ForceMode2D.Impulse);
        }

        if(rigidbody.velocity.y > 0) {
            collider.isTrigger = true;
        }
        else {
            collider.isTrigger = false;
        }
	}

    void Change_Direction() {
        angle.Set(0, (int)direction, 0);
        character.transform.eulerAngles = angle;
    }

    void Attack(int combo) {
        GameObject gO= ObjectPool.access.Pop("laser", gameObject.transform);
        gO.transform.parent = gameObject.transform;
        gO.SendMessage("Init", direction);
    }
}
