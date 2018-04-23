using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour 
{
	public float speed;
	public float timer=0.1f;
	
	void Start()
	{
		gameObject.SendMessage("GiveSpeed", speed);
	}
	
	void FixedUpdate()
	{
		timer-=Time.deltaTime*1;
		if(timer<0)
		{
			Push();
			GetComponent<Rigidbody2D>().angularVelocity = Random.Range(500,500);
			Destroy(this);
		}
	}
	
	void Push()
	{
		gameObject.SendMessage("GetInput", 2);
	}
	
	

	
}
