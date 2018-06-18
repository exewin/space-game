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
	
	SingleWave myWave;
	
	[Header("PlayerOnly")]
	public AudioClip hitSound; //only for player
	public AudioClip shieldSound; //only for player
	public GameObject UI; //only for player
	public GameObject UIGameOver; //only for player
	
	
	[Header("MeteorOnly")]
	public GameObject alternativeDestroyEffect;

	void Start()
	{
		if(gameObject.tag=="Enemy")
		{
			myWave = GameObject.FindWithTag("Wave").GetComponent<SingleWave>();
		}
		
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
			{
				Instantiate(hitEffect,hitPoint,transform.rotation);
			}
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
	
	void PickupHealthPack(int heal)
	{
		if(heal<=maxHp-hp)
			hp+=heal;
		else
			hp=maxHp;
		
		AdjustUI();
	}
	
	
	
	public void Annihilation()
	{
		if(destroyOrigin==null)
			destroyOrigin=gameObject.transform;
		
		GameObject eff;
		
		if(!killAfter)
			eff = Instantiate(destroyEffect,destroyOrigin.position,Quaternion.Euler(transform.rotation.x,transform.rotation.y,Random.Range(0,360)));
		else
			eff = Instantiate(alternativeDestroyEffect,destroyOrigin.position,Quaternion.Euler(transform.rotation.x,transform.rotation.y,Random.Range(0,360)));
		
		if(gameObject.tag=="Meteor")
		{
			eff.transform.localScale = transform.lossyScale*15;
		}
		
		if(gameObject.tag=="Enemy"&&part==false)
		{
			SendMessage("SpawnPickup",null);
			if(myWave)
				myWave.Reduce();
		}
	
		if(isPlayer)
		{
			Time.timeScale=0f;
			UIGameOver.SetActive(true);
		}
		
		Destroy(gameObject);
		
	}
	
	public void AdjustUI()
	{
		UI.GetComponent<Text>().text=""+hp;
	}
}
