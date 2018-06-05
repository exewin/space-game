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
	
	public GameObject[] UI;
	public Sprite[] bonusIcons;
	
	//1-weaponary
	//2-laser
	//3-engine boost
	//4-super projectiles
	//5-rapid fire
	
	public float[] timers;
	public GameObject[] UI_timers;
	public bool allowTimers;
	
	void PickupBonus(int type)
	{
		//check if same type already exists, if so overwrite
		for(int h = 0; h < 3; h++)
		{
			if(types[h]==type)
			{
				ConfirmBonus(h, type);
				return;
			}
		}

		//check free space for bonus, if so assign
		for(int i = 0; i < 3; i++)
		{
			if(types[i]==0)
			{
				Activator(i, true);
				ConfirmBonus(i, type);
				return;
			}
		}

		//overwrite bonus with shortest timer
		float lowest = 20;
		int index=0;
		for(int j = 0; j < 3; j++)
		{
			if(timers[j]<lowest)
			{
				index=j;
				lowest=timers[j];
			}
		}
		
		ConfirmBonus(index, type);
			

		
	}
	
	void Update()
	{
		
		if(allowTimers)
		{
			for(int i = 0; i < 3; i++)
			{
				if(timers[i]>0)
				{
					timers[i]-=Time.deltaTime*1;
					if(timers[i]>=10)
						UI_timers[i].GetComponent<Text>().text=""+timers[i].ToString("F2");
					else
						UI_timers[i].GetComponent<Text>().text="0"+timers[i].ToString("F2");
				}
				else
				{
					types[i]=0;
					SortBonuses(i);
				}
			}
			
		}
		
	}
	
	
	void Activator(int index, bool mode)
	{
		UI[index].SetActive(mode);
		UI_timers[index].SetActive(mode);

	}
	
	void ConfirmBonus(int index, int type)
	{
		UI[index].GetComponent<Image>().sprite=bonusIcons[type-1];
		types[index]=type;
		timers[index]=5;
	}
	
	void Deconfirm(int index)
	{
		types[index]=0;
		timers[index]=0;
		UI[index].GetComponent<Image>().sprite=null;
	}

	void SortBonuses(int index)
	{
		if(index==0)
		{
			UI[0].GetComponent<Image>().sprite=UI[1].GetComponent<Image>().sprite;
			types[0]=types[1];
			timers[0]=timers[1];
			
			Deconfirm(1);
		}
		if(index==0||index==1)
		{
			UI[1].GetComponent<Image>().sprite=UI[2].GetComponent<Image>().sprite;
			types[1]=types[2];	
			timers[1]=timers[2];
			
			Deconfirm(2);
		}
		
		for(int i = 0; i < 3; i++)
		{
			if(types[i]==0)
				Activator(i, false);
		}
	}
	
}









