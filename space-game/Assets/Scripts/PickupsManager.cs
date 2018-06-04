using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupsManager : MonoBehaviour 
{

	//numb of max pickup bonuses = 3
	
	public int[] types;
	
	public MouseActions mouseActions;
	public Weapons weapons;
	public Movement movement;
	
	public GameObject[] UIs;
	public Texture2D[] bonusIcons;
	
	//1-weaponary
	//2-laser
	//3-engine boost
	//4-super projectiles
	//5-rapid fire
	
	public float[] timers;
	public bool allowTimers;
	
	void PickupBonus(int type)
	{
		
		for(int i = 0; i < 3; i++)
		{
			if(types[i]==null)
			{
				types[i]=type;
				timers[i]=20;
				break;
			}
		}
		
	}
	
	void Update()
	{
		
		if(allowTimers)
		{
			for(int i = 0; i < 3; i++)
			{
				if(timers[i]>0)
					timers[i]-=Time.deltaTime*1;
				else
					types[i]=0;
			}
			
		}
		
	}

}
