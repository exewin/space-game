using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toughness : MonoBehaviour 
{

	public int maxHp;
	public int hp;
	public bool isPlayer;
	public bool part;
	Shield shield;
	HpBar hpbar;
	public GameObject destroyEffect;
	[Header("Optional")]
	public GameObject hitEffect;
	public Transform destroyOrigin;
	[HideInInspector]
	public bool killAfter;
	
	WaveController waveController;
	
	[Header("PlayerOnly")]
	public AudioClip hitSound; //only for player
	public AudioClip shieldSound; //only for player
	public GameObject UI; //only for player
	

	void Start()
	{
		if(gameObject.tag=="Enemy")
			waveController = GameObject.Find("WaveController").GetComponent<WaveController>();
		
		hp=maxHp;
		
		if(isPlayer)
		{
			shield=GetComponent<Shield>();
			AdjustUI();
		}
		else
		{
			hpbar = GameObject.Find("EnemyHp").GetComponent<HpBar>();
		}
		
	}
	//args
	//0 dmg
	//1 arp - deleted
	//2 pointx
	//3 pointy
	void Damage(int[] arg)
	{
		Vector2 hitPoint = new Vector2(arg[2],arg[3]); 

		if(isPlayer)
		{
			if(shield.used)
			{
				AudioSource.PlayClipAtPoint(shieldSound, new Vector3(3,0,0));
				if(arg[0]<=shield.energy)
				{
					shield.energy-=arg[0];
					arg[0]=0;
				}
				else
				{
					arg[0]-=Mathf.FloorToInt(shield.energy);
					shield.energy=0;
				}
			}
		}

		if(arg[0]>0)
		{
			hp-=arg[0];
			if(isPlayer)
			{
				AudioSource.PlayClipAtPoint(hitSound, new Vector3(3,0,0));
			}
			if(hitEffect)
				Instantiate(hitEffect,hitPoint,transform.rotation);
		}
		
		if(isPlayer)
			AdjustUI();
		else
		{
			hpbar.target=gameObject;
			hpbar.UpdateInt();
		}
		
		
		if(hp<=0)
			Annihilation();
		
		
		
	}
	
	void PickupR(int heal)
	{
		if(heal<=maxHp-hp)
			hp+=heal;
		else
		{
			SendMessage("AddXP",heal-(maxHp-hp));
			hp=maxHp;
		}
		
		AdjustUI();
	}
	
	
	public void Annihilation()
	{
		//effect
		if(destroyOrigin==null)
			destroyOrigin=gameObject.transform;
		
		GameObject eff = Instantiate(destroyEffect,destroyOrigin.position,Quaternion.Euler(transform.rotation.x,transform.rotation.y,Random.Range(0,360)));
		if(killAfter)
			Destroy(eff.GetComponent<PlayAtPoint>());
		
		if(gameObject.tag=="Enemy"&&part==false)
		{
			SendMessage("SpawnPickup",null);
			waveController.Reduce();
		}
		
		Destroy(gameObject);
		
	}
	
	public void AdjustUI()
	{
		UI.GetComponent<Text>().text=""+hp;
	}
}
