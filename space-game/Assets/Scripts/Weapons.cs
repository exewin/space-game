using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour 
{
	public bool isPlayer;
	[HideInInspector]
	public float speedBonus=1f;
	[HideInInspector]
	public float damageBonus=1f;
	[HideInInspector]
	public bool weaponaryBonus=false;
	
	[System.Serializable]
	public class Weapon
	{
		[HideInInspector]
		public bool isPlayer;
		[HideInInspector]
		public string nameTag;
		[HideInInspector]
		public float nextFire = 0.0f;
		[HideInInspector]
		public Weapons playerScript;
		
		
		public GameObject projectile;
		public float fireRate;
		public Transform[] spawnPoint;

		public void Shoot()
		{
			if(Time.time > nextFire)
			{
				for(int i=0;i<spawnPoint.Length;i++)
				{
					if(this.spawnPoint[i]!=null)
					{
						GameObject spawn = Instantiate(this.projectile,this.spawnPoint[i].position,this.spawnPoint[i].rotation);
						if(isPlayer)
						{
							spawn.GetComponent<Projectile>().speed*=playerScript.speedBonus;
							spawn.GetComponent<Projectile>().damage*=playerScript.damageBonus;
						}
						spawn.SendMessage("GiveOwner",nameTag);
						
						
						if(!isPlayer || playerScript.weaponaryBonus)
							nextFire = Time.time + this.fireRate;
						else
							playerScript.FillNextFires();
					}
				}
			}
		}
	}
	
	public Weapon[] Wpns;
	
	void Start()
	{
		
		for(int i = 0;i<Wpns.Length;i++)
		{
			if(isPlayer)
				Wpns[i].playerScript=this;
			Wpns[i].nameTag=gameObject.tag;
			Wpns[i].isPlayer=isPlayer;
		}
	}
	
	
	void Shoot(int canonId)
	{
		if(Wpns.Length>canonId)
			Wpns[canonId].Shoot();
	}
	
	public void FillNextFires()
	{
		for(int i = 0;i<Wpns.Length;i++)
		{
			Wpns[i].nextFire = Time.time + Wpns[i].fireRate;
		}
	}
	
	void PickupSP(float multiplier)
	{
		speedBonus*=multiplier;
		damageBonus*=multiplier;
	}
	
	void PickupRF(float multiplier)
	{
		for(int i = 0;i<Wpns.Length;i++)
		{
			Wpns[i].fireRate/=multiplier;
		}
	}
	
	void PickupW(bool mode)
	{
		weaponaryBonus=mode;
	}
	
}
