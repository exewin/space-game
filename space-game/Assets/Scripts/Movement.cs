﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour 
{


	public float speed;
	Rigidbody2D rb;
	Vector3 screenPosition;
	
	public bool meteorImmune; //KBUM special
	
	[Header("PlayerOnly")]
	public float maxSpeed;
	
	
	
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		
		if(gameObject.tag=="Enemy")
		{
			if(StaticVars.level==1)
				speed-=speed/3;
			
			if(StaticVars.level==3)
				speed+=speed/2;
		}
		
	}
	
	
	//1-up
	//2-down
	//3-left
	//4-right
	void GiveSpeed(float newSpeed)
	{
		speed=newSpeed;
	}
	
	void GetInput(int input)
	{
		if(!rb)
		{
			return;
		}
		if(input==1)
		{
			rb.AddForce(transform.up * speed);
		}
		else if(input==2)
		{
			rb.AddForce(-transform.up * speed);
		}
		else if(input==3)
		{
			rb.AddForce(-transform.right * speed);
		}
		else if(input==4)
		{
			rb.AddForce(transform.right * speed);
		}
		
	}
	
	//Mini1's downside
	void Push(int force)
	{
		if(!rb)
			return;

		rb.AddForce(-transform.up *  force);
	}
	
	void OnCollisionEnter2D(Collision2D coll) 
	{
		int[] bulletInfo;
		if(coll.gameObject.tag!="Border")
			if (coll.gameObject.tag != gameObject.tag || coll.gameObject.tag=="Meteor" && gameObject.tag=="Meteor")
			{
				if(coll.gameObject.tag=="Enemy"&&gameObject.tag=="Meteor")
				{
					if(coll.gameObject.GetComponent<Movement>().meteorImmune==true)
						return;
				}
				
				bulletInfo = new int[4];
				bulletInfo[0] = ((int)rb.velocity.magnitude+(int)coll.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude)*4/5;
					bulletInfo[1] = 0; //this is unused - it was created for armor
				
				foreach (ContactPoint2D missileHit in coll.contacts)
				{
					Vector2 hitPoint = missileHit.point;
					bulletInfo[2] = (int) hitPoint.x;
					bulletInfo[3] = (int) hitPoint.y;
				}
				
				if(bulletInfo[0]>5)
					coll.gameObject.SendMessage("Damage", bulletInfo);
			}
	}
	
	void OnCollisionOver2D(Collision2D coll) 
	{
		OnCollisionEnter2D(coll);
	}
	
}










