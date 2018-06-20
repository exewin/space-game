using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUper : MonoBehaviour 
{
	int exp=0;
	int reqExp=10;
	int level=0;
	public GameObject UI;
	public GameObject UI2;
	public PickupsManager pickupMan;
	public Weapons[] WeaponsPresets;
	
	void Start()
	{
		LevelUp(0);
		AdjustUI();
	}
	
	void LevelUp (int level)
	{
		Destroy(GetComponent<Weapons>());
		Weapons wpns = gameObject.AddComponent<Weapons>() as Weapons;
		wpns.Wpns = WeaponsPresets[level].Wpns;
		wpns.Configure();
		pickupMan.weapons = wpns;
		SendMessage("ReApplyBonus", 1);
	}
	
	void PickupExperiencePack(int xp)
	{
		exp+=xp;
		if(exp>=reqExp)
		{
			level++;
			reqExp=reqExp+(level+1)*10+15;
			LevelUp(level);
			if(level==WeaponsPresets.Length-1)
				reqExp=99999;
		}
		AdjustUI();
	}
	
	void AdjustUI()
	{
		UI.GetComponent<Text>().text=""+reqExp;
		UI2.GetComponent<Text>().text=""+exp;
	}
	
}
