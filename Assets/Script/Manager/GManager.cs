using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
    player = 0,
    projectile = 1,
    enemy = 2
}

[System.Serializable]
public class GManager : Singleton<GManager> 
{
    
    public delegate void Buff(float rate = 0);


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Object_Move(GameObject _object, Direction direction)
    {
        _object.BroadcastMessage("Move", direction);
    }

    public void Object_Move_Stop(GameObject _object)
    {
        _object.BroadcastMessage("Move_Stop");
    }

    public void Object_Move(GameObject _object, Vector2 move_vector)
    {
        _object.BroadcastMessage("Move", move_vector);
    }

    public void Object_Jump(GameObject _object)
    {
        _object.BroadcastMessage("Jump");
    }

    public void Object_Dash(GameObject _object)
    {
        _object.BroadcastMessage("Dash");
    }

    public void Object_Hit(GameObject hit_object, float damage) 
    {
        hit_object.BroadcastMessage("Hit", damage);
    }

    public void Objcet_Buff(GameObject hit_object, int buff_num)
    {
        hit_object.BroadcastMessage("Debuff", buff_num);
    }
}
