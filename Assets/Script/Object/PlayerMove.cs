using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    //============================
    // Component
    //============================

    Rigidbody2D rigid;
    Collider2D collid;
    GameObject character_object;



    //============================
    // Enum
    //============================
    [SerializeField]
    Direction direction = Direction.right;



    //============================
    // Delegate
    //============================

    public delegate void Dash_Delegate(float rate = 0);
    public delegate void Move_Delegate(float rate = 0);
    public delegate void Jump_Delegate(float rate = 0);



    //============================
    // Event
    //============================

    public event Dash_Delegate dash_event;
    public event Move_Delegate move_event;
    public event Jump_Delegate jump_event;



    //============================
    // Vector
    //============================

    Vector3 angle = new Vector3();



    //============================
    // Stat
    //============================

    float speed;

    [Space]

    [Header("Dash")]
    public bool is_dash;
    float dash_dis;
    float dash_speed;

    [Space]

    [Header("Jump")]
    public bool is_jumping;
    float jump_power;
    float jump_count_max;
    float jump_count_cur;



    //============================
    // Coroutine
    //============================

    IEnumerator DashCoroutine()
    {
        float dis = 0;
        is_dash = true;

        rigid.velocity = Vector2.zero;
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





    //============================
    // Initialize
    //============================

    void Awake()
    {
        rigid = transform.GetComponent<Rigidbody2D>();
        collid = transform.GetComponent<Collider2D>();
        character_object = transform.GetChild(0).gameObject;
    }


    void Start()
    {
        character_object.SendMessage("Init");
    }

    public void Init_Move(float speed, float dash_dis, float dash_speed, float jump_power, float jump_count_max)
    {
        this.speed = speed;
        this.dash_dis = dash_dis;
        this.dash_speed = dash_speed;
        this.jump_power = jump_power;
        this.jump_count_max = jump_count_max;
    }

    //============================
    // Update
    //============================

    void Update ()
    {
        if (rigid.velocity.y > 0)
        {
            collid.isTrigger = true;
        }
        else
        {
            collid.isTrigger = false;
        }
	}



    //============================
    // Move Handling
    //============================

    private void Move(Direction direc)
    {
        if (move_event != null)
            move_event();

        Change_Direction(direc);

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


    protected virtual void Dash()
    {
        StartCoroutine(DashCoroutine());
    }


    protected virtual void Jump()
    {
        if (jump_event != null)
            jump_event();

        if (jump_count_cur < jump_count_max && !is_dash)
        {
            rigid.velocity = Vector2.up * jump_power;
            jump_count_cur++;
            is_jumping = true;
        }
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



    //============================
    // Collision Handling
    //============================

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block") && is_jumping)
        {
            jump_count_cur = 0;
            is_jumping = false;
        }
    }
}
