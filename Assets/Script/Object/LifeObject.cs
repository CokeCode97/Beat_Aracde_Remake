using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    left = 180,
    right = 0
}

[System.Serializable]
public class LifeObject : MonoBehaviour 
{   
    //============================
    // Delegate
    //============================

    public delegate void Hit_Delegate(float damage = 0);
    public delegate void Buff_Delegate(float rate = 0);
    public delegate void Attack_Delegate(float rate = 0);
    public delegate void Skill_Delegate(float rate = 0);
    public delegate void Dash_Delegate(float rate = 0);
    public delegate void Move_Delegate(float rate = 0);
    public delegate void Jump_Delegate(float rate = 0);
    public delegate void Die_Delegate(float rate = 0);
    public delegate void Change_Direction_Delegate(float rate = 0);


    //============================
    // Event
    //============================

    public event Hit_Delegate hit_event;
    public event Buff_Delegate buff_event;
    public event Attack_Delegate attack_event;
    public event Skill_Delegate skill_event;
    public event Dash_Delegate dash_event;
    public event Move_Delegate move_event;
    public event Jump_Delegate jump_event;
    public event Die_Delegate die_event;
    public event Change_Direction_Delegate change_direction_event;


    //============================
    // Component
    //============================

    Rigidbody2D parent_rigidbody2d;
    Transform parent_transform;
    Collider2D parent_collider2d;


    //============================
    // Vector
    //============================

    Vector3 angle = new Vector3();
    Vector2 dash_vector = new Vector2(-5,0);

    //============================
    // Stat
    //============================

    [SerializeField]
    Direction direction = Direction.right;
    public float hp;
    public float speed;
    public float jump_power;
    public float armor;
    public float attack;

    public float dash_dis;
    public float dash_speed;
    public bool is_dash;

    public float jump_count_max;
    public float jump_count_cur;

    public float y_vel;

    IEnumerator DashCoroutine()
    {
        float dis = 0;
        parent_rigidbody2d.velocity = new Vector2(0, 0);
        parent_rigidbody2d.gravityScale = 0;

        while (dis < dash_dis)
        {
            if (direction.Equals(Direction.left))
                parent_transform.Translate(-dash_speed * Time.deltaTime, 0, 0);
            else
                parent_transform.Translate(dash_speed * Time.deltaTime, 0, 0);
            dis += dash_speed * Time.deltaTime;

            yield return null;
        }
        is_dash = false;
        parent_rigidbody2d.velocity = new Vector2(0,0);
        parent_rigidbody2d.gravityScale = 1;
    }


    // Use this for initialization
    void Awake()
    {
        parent_rigidbody2d = transform.parent.GetComponent<Rigidbody2D>();
        parent_collider2d = transform.parent.GetComponent<Collider2D>();
        parent_transform = transform.parent.GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (parent_rigidbody2d.velocity.y > 0)
        {
            parent_collider2d.isTrigger = true;
        }
        else
        {
            parent_collider2d.isTrigger = false;
        }

        y_vel = parent_rigidbody2d.velocity.y;
	}

    protected virtual void Move(Direction direction)
    {
        if(move_event != null)
            move_event();

        Change_Direction(direction);

        if(direction.Equals(Direction.left))
            transform.parent.Translate(Vector2.left * speed * Time.deltaTime);
        else
            transform.parent.Translate(Vector2.right * speed * Time.deltaTime);
    }

    protected virtual void Move(Vector2 move_vector) 
    {
        if (move_event != null)
            move_event();
        parent_rigidbody2d.AddForce(move_vector, ForceMode2D.Impulse);
    }

    protected virtual void Jump() 
    {
        if (jump_event != null)
            jump_event();

        if (jump_count_cur < jump_count_max && !is_dash)
        {
            parent_rigidbody2d.velocity = Vector2.up * jump_power;
            jump_count_cur++;
        }
    }

    protected virtual void Dash() 
    {
        StartCoroutine(DashCoroutine());
        is_dash = true;
    }

    protected virtual void Hit(int damage) 
    { 
        if (hit_event != null)
            hit_event();

        hp -= damage;
        if(hp <= 0)
        {
            Die();
        }
    }

    protected virtual void buff(int buff_num) { }

    protected virtual void Attack() { }

    protected virtual void Skill() { }





    protected virtual void Change_Direction(Direction direction) 
    {
        if (!this.direction.Equals(direction))
        {
            this.direction = direction;
            angle.Set(0, (int)direction, 0);
            gameObject.transform.eulerAngles = angle;
        }
    }

    protected virtual void Die() { }

    void Jump_Reset()
    {
        jump_count_cur = 0;
    }
}
