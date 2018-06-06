using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour 
{
	
	public float speed=3;
	public float damage=5;
	public float maxDamage=6;
	public byte penetrableRate=1;
	int[] bulletInfo;
	[HideInInspector]
	public string ownerTag;
	public AudioClip sound;
	
	[Header("Optional")]
	public GameObject boomEffect;
	public AudioClip destroySound;
	
	void Start()
	{
		
		//adjust difficulty level
		if(ownerTag=="Enemy")
		{
			if(StaticVars.level==1)
			{
				speed-=speed/3;
				damage-=damage/3;
			}
			
			if(StaticVars.level==3)
			{
				speed+=speed/2;
				damage+=damage/2;
			}
		}
		
		if(sound)
			AudioSource.PlayClipAtPoint(sound, new Vector3(5,0,0));
		bulletInfo = new int[4];
		bulletInfo[0] = (int)Random.Range(damage,maxDamage);
	}
	
	void Update () 
	{
		transform.Translate(0,speed*Time.deltaTime,0);
	}
	
	
	void OnTriggerStay2D(Collider2D coll) 
	{
		if (coll.gameObject.tag != "Untagged" && coll.gameObject.tag != ownerTag)
		{
			//add dmg rocket vs meteor
			if (gameObject.tag=="Rocket"&&coll.gameObject.tag=="Meteor")
				bulletInfo[0] *= 6;
			
			RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up);
			if(hit.collider != null)
			{
				bulletInfo[2]=(int)hit.point.x;
				bulletInfo[3]=(int)hit.point.y;
			}
			
			
			coll.gameObject.SendMessage("Damage", bulletInfo);
			
			if(boomEffect)
				Instantiate(boomEffect,transform.position,transform.rotation);
			if(destroySound)
				AudioSource.PlayClipAtPoint(destroySound, transform.position);
			
			Penetration();
		}
	}
	
	void Penetration()
	{
		penetrableRate--;
		if(penetrableRate<=0)
		{
			Destroy(gameObject);
		}
	}
	
	void GiveOwner(string tag)
	{
		ownerTag=tag;
	}
	
}
