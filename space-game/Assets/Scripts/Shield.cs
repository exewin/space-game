using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour 
{
	
	public bool used;
	public float energy;
	public float maxShield;
	public float shieldRegen;
	public GameObject gpx;
	public GameObject UI;
	public SpriteRenderer shipGpx;
	
	void Start()
	{
		AdjustUI();
	}

	void ShieldMe(int mode)
	{
		//active
		if(mode==1&&!used)
		{
			if(energy>10)
			{
				Active();
			}
			else
			{
				Unactive();
			}
		}
		//unactive
		else if(mode==2)
		{
			Unactive();
		}
	}
	
	void Active()
	{
		energy-=8;
		used=true;
		gpx.SetActive(true);
		shipGpx.color= new Color(0.45f,0.97f,0.58f);
	}
	
	void Unactive()
	{
		used=false;
		gpx.SetActive(false);
		shipGpx.color= new Color(1f,1f,1f);
	}
	
	void Update()
	{
		if(used)
		{
			gpx.transform.localScale = new Vector3(1.1f + Mathf.PingPong(Time.time*.4f, .1f), 1.1f + Mathf.PingPong(Time.time*.6f, .1f), 1);
			energy-=Time.deltaTime*5;
			if(energy<0.1)
			{
				Unactive();
			}
		}
		else if(energy<maxShield)
		{
			energy+=Time.deltaTime*shieldRegen;
		}
		AdjustUI();
	}
	

	void AdjustUI()
	{
		UI.GetComponent<Text>().text=""+Mathf.FloorToInt(energy);
	}
	
	
	void PickupShieldPack(int multiplier)
	{
		energy+=multiplier;
		if(energy>maxShield)
			energy=maxShield;
	}
	

	
}
