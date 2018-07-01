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
   
    public delegate void Die_Delegate(float rate = 0);
    public delegate void Change_Direction_Delegate(float rate = 0);


    //============================
    // Event
    //============================

    public event Hit_Delegate hit_event;
    public event Buff_Delegate buff_event;
    public event Attack_Delegate attack_event;
    public event Skill_Delegate skill_event;

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



    //============================
    // Stat
    //============================



    public float hp;
    public float armor;
    public float attack;






	
	// Update is called once per frame
	void Update () 
    {
        
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







    protected virtual void Die() { }
}
