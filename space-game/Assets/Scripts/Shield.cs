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
	}
	
	void Unactive()
	{
		used=false;
		gpx.SetActive(false);
	}
	
	void Update()
	{
		if(used)
		{
			gpx.transform.localScale = new Vector3(Random.Range(1.1f,1.2f), Random.Range(1.1f,1.2f), 1);
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
		
		
		//pst, you want some cheats?
		if(Input.GetKey(KeyCode.RightShift)&&Input.GetKeyDown(KeyCode.LeftShift))
		{
			energy=99999;
			gameObject.SendMessage("ShieldMe",1);
			gameObject.GetComponent<Movement>().speed=2000f;
		}
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
