using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUper : MonoBehaviour 
{
	int exp=0;
	int reqExp=25;
	int level=0;
	public GameObject UI;
	
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
	}
	
	void AddXP(int xp)
	{
		exp+=xp;
		if(exp>=reqExp)
		{
			level++;
			LevelUp(level);
			exp-=reqExp;
			reqExp=reqExp*2/3;
		}
		AdjustUI();
	}
	
	void AdjustUI()
	{
		UI.GetComponent<Text>().text=""+(reqExp-exp);
	}
}
