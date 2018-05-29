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
	public float fireRateBonus=1;
	[HideInInspector]
	public bool weaponaryBonus=false;
	
	public bool autoFire;
	
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
		public Weapons Wscript;
		
		
		public GameObject projectile;
		public float fireRate;
		public Transform[] spawnPoint;

		public void Shoot()
		{
			if(Time.time > nextFire)
			{
				
				if(!isPlayer)
					Wscript.SendMessage("ShootConfirmed",1);
				
				for(int i=0;i<spawnPoint.Length;i++)
				{
					if(this.spawnPoint[i]!=null)
					{
						
						GameObject spawn = Instantiate(this.projectile,this.spawnPoint[i].position,this.spawnPoint[i].rotation);
						if(isPlayer)
						{
							spawn.GetComponent<Projectile>().speed*=Wscript.speedBonus;
							spawn.GetComponent<Projectile>().damage*=Wscript.damageBonus;
						}
						spawn.SendMessage("GiveOwner",nameTag);
						
						if(!isPlayer)
						{
							nextFire = (Time.time + this.fireRate) ;
						}
						else
						{
							if(Wscript.weaponaryBonus)
								nextFire = (Time.time + this.fireRate/Wscript.fireRateBonus) ;
							else
								Wscript.FillNextFires();
						}
						
					}
				}
			}
		}
	}
	
	public Weapon[] Wpns;
	
	void Start()
	{
		Configure();
	}
	public void Configure()
	{
		if(gameObject.tag=="Player")
			isPlayer=true;
		for(int i = 0;i<Wpns.Length;i++)
		{
			Wpns[i].Wscript=this;
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
			Wpns[i].nextFire = Time.time + Wpns[i].fireRate/fireRateBonus;
		}
	}
	
	void PickupSP(float multiplier)
	{
		speedBonus=multiplier;
		damageBonus=multiplier;
	}
	
	void PickupRF(float multiplier)
	{
		fireRateBonus=multiplier;
	}
	
	void PickupW(bool mode)
	{
		weaponaryBonus=mode;
	}
	
	void Update()
	{
		if(autoFire)
			Wpns[0].Shoot();
	}
	
}
