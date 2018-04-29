using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour 
{
	public float speed;
	public float timer=0.1f;
	bool done;
	
	void Start()
	{
		gameObject.SendMessage("GiveSpeed", speed);
	}
	
	void FixedUpdate()
	{
			timer-=Time.deltaTime*1;
		
		if(timer<0&&done==false)
		{
			Push();
			GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-500,500);
			done=true;
		}
		
		if(timer<-10)
		{
			GetComponent<Toughness>().killAfter=true;
			GetComponent<Toughness>().Annihilation();
		}
	}
	
	void Push()
	{
		gameObject.SendMessage("GetInput", 1);
	}
	
	

	
}
