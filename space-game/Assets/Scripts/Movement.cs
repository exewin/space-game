using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour 
{

	
	public float speed;
	Rigidbody2D rb;
	Vector3 screenPosition;
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
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
	
	void OnCollisionEnter2D(Collision2D coll) 
	{
		int[] bulletInfo;
		if(coll.gameObject.tag!="Border")
			if (coll.gameObject.tag != gameObject.tag || coll.gameObject.tag=="Meteor" && gameObject.tag=="Meteor")
			{
				bulletInfo = new int[4];
				bulletInfo[0] = ((int)rb.velocity.magnitude+(int)coll.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude)*4/5;
				bulletInfo[1] = 0;
				
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
	
	void PickupEB(float multi)
	{
		speed*=multi;
	}
	
}










