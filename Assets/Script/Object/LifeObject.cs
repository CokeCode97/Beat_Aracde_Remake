using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LifeObject : MonoBehaviour {
    [SerializeField]
    float hp;
    float speed;
    float jump_power;
    float armor;
    float attack;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected virtual void Hit(int damage) { }

    protected virtual void Attack() { }

    protected virtual void Skill() { }

    protected virtual void Dash() { }

    protected virtual void Move() { }

    protected virtual void Jump() { }

    protected virtual void Change_Direction(Direction direction) { }

    protected virtual void Die() { }

}
