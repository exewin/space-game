using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUper : MonoBehaviour 
{
	int exp=0;
	int reqExp=10;
	public int level=0;
	public GameObject UI;
	public GameObject UI2;
	public PickupsManager pickupMan;
	public Weapons[] WeaponsPresets;
	
	
	public void LevelUp (int level)
	{
		Destroy(GetComponent<Weapons>());
		Weapons wpns = gameObject.AddComponent<Weapons>() as Weapons;
		wpns.Wpns = WeaponsPresets[level].Wpns;
		wpns.Configure();
		pickupMan.weapons = wpns;
		SendMessage("ReApplyBonus", 1);
	}
	
	public void PickupExperiencePack(int xp)
	{
		exp+=xp;
		
		while(exp>=reqExp)
		{
			level++;
			reqExp=reqExp+(level+1)*10+15;
			if(level==WeaponsPresets.Length-1)
				reqExp=99999;
			
		}
		LevelUp(level);
		AdjustUI();
	}
	
	void AdjustUI()
	{
		UI.GetComponent<Text>().text=""+reqExp;
		UI2.GetComponent<Text>().text=""+exp;
	}
	
}
