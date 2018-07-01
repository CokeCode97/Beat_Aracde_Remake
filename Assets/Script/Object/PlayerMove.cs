using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    Rigidbody2D rigid;
    Collider2D collider;

    GameObject character_object;

    [SerializeField]
    Direction direction = Direction.right;

    public delegate void Dash_Delegate(float rate = 0);
    public delegate void Move_Delegate(float rate = 0);
    public delegate void Jump_Delegate(float rate = 0);

    public event Dash_Delegate dash_event;
    public event Move_Delegate move_event;
    public event Jump_Delegate jump_event;


    public float speed;
    public float jump_power;

    public float dash_dis;
    public float dash_speed;
    public bool is_dash;

    public float jump_count_max;
    public float jump_count_cur;


    Vector3 angle = new Vector3();

    IEnumerator DashCoroutine()
    {
        float dis = 0;
        rigid.velocity = new Vector2(0, 0);
        rigid.gravityScale = 0;

        while (dis < dash_dis)
        {
            if (direction.Equals(Direction.left))
                transform.Translate(-dash_speed * Time.deltaTime, 0, 0);
            else
                transform.Translate(dash_speed * Time.deltaTime, 0, 0);
            dis += dash_speed * Time.deltaTime;

            yield return null;
        }
        is_dash = false;
        rigid.velocity = new Vector2(0, 0);
        rigid.gravityScale = 1;
    }


    // Use this for initialization
    void Awake()
    {
        rigid = transform.GetComponent<Rigidbody2D>();
        collider = transform.GetComponent<Collider2D>();
        character_object = transform.GetChild(0).gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        //if(Input.GetKey(KeyCode.LeftArrow))
        //{
        //    Move(Direction.left);
        //}
        //if(Input.GetKey(KeyCode.RightArrow))
        //{
        //    Move(Direction.right);
        //}
        //if(Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    Jump();
        //}

        if (rigid.velocity.y > 0)
        {
            collider.isTrigger = true;
        }
        else
        {
            collider.isTrigger = false;
        }
	}


    protected virtual void Move(Direction direction)
    {
        if (move_event != null)
            move_event();

        Change_Direction(direction);

        if (direction.Equals(Direction.left))
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        else
            transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    protected virtual void Move(Vector2 move_vector)
    {
        if (move_event != null)
            move_event();
        rigid.AddForce(move_vector, ForceMode2D.Impulse);
    }

    protected virtual void Jump()
    {
        if (jump_event != null)
            jump_event();

        if (jump_count_cur < jump_count_max && !is_dash)
        {
            rigid.velocity = Vector2.up * jump_power;
            jump_count_cur++;
        }
    }

    protected virtual void Dash()
    {
        StartCoroutine(DashCoroutine());
        is_dash = true;
    }

    protected virtual void Change_Direction(Direction direction)
    {
        if (!this.direction.Equals(direction))
        {
            this.direction = direction;
            angle.Set(0, (int)direction, 0);
            character_object.transform.eulerAngles = angle;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            jump_count_cur = 0;
            print("착지");
        }
    }
}
