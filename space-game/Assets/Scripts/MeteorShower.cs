using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeteorShower : MonoBehaviour 
{

	public GameObject[] MeteorSpawner;
	public GameObject[] Mindicator;
	
	
	void CallMe ()	
	{
		MeteorSpawner = GameObject.FindGameObjectsWithTag("MeteorSpawner");
		if(MeteorSpawner[0]!=null)
		{
			for(int i = 0; i < MeteorSpawner.Length; i++)
			{
				Vector2 positionOnScreen = Camera.main.WorldToScreenPoint (MeteorSpawner[i].transform.position);
				float x = positionOnScreen.x;
				float y = positionOnScreen.y;
				byte typeX=0;
				byte typeY=0;
				
				//<x -138 
				//x> -54
				//y^ -19
				//yV -77
				
				if(x > 325 & x < 1556)
					typeX=0;
				else if(x >= 1556)
					typeX=1;
				else if(x <= 325)
					typeX=2;
				
				if(y > 34 & y < 847)
					typeY=0;
				else if(y >= 847)
					typeY=1;
				else if(y <= 34)
					typeY=2;
				
				if(typeX==0)
				{
					if(typeY==1)
					{
						Mindicator[i].GetComponent<RectTransform>().position = new Vector2(x,Screen.height-32);
						Mindicator[i].GetComponent<RectTransform>().eulerAngles=new Vector3(0,0,0);
					}
					else if(typeY==2)
					{
						Mindicator[i].GetComponent<RectTransform>().position = new Vector2(x,32);
						Mindicator[i].GetComponent<RectTransform>().eulerAngles=new Vector3(0,0,180);
					}
				}
				else if(typeX==1)
				{
					if(typeY==0)
					{
						Mindicator[i].GetComponent<RectTransform>().position = new Vector2(Screen.width-32,y);
						Mindicator[i].GetComponent<RectTransform>().eulerAngles=new Vector3(0,0,-90);
					}
					else if(typeY==1)
					{
						Mindicator[i].GetComponent<RectTransform>().position = new Vector2(Screen.width-32,Screen.height-32);
						Mindicator[i].GetComponent<RectTransform>().eulerAngles=new Vector3(0,0,-45);
					}
					else if(typeY==2)
					{
						Mindicator[i].GetComponent<RectTransform>().position = new Vector2(Screen.width-32,32);
						Mindicator[i].GetComponent<RectTransform>().eulerAngles=new Vector3(0,0,-135);
					}
				}
				
				else if(typeX==2)
				{
					float tmp=Screen.width;
					float help=(int)(280f/(1366f/tmp));
					if(typeY==0)
					{
						Mindicator[i].GetComponent<RectTransform>().position = new Vector2(help,y);
						Mindicator[i].GetComponent<RectTransform>().eulerAngles=new Vector3(0,0,90);
					}
					else if(typeY==1)
					{
						Mindicator[i].GetComponent<RectTransform>().position = new Vector2(help,Screen.height-32);
						Mindicator[i].GetComponent<RectTransform>().eulerAngles=new Vector3(0,0,45);
					}
					else if(typeY==2)
					{
						Mindicator[i].GetComponent<RectTransform>().position = new Vector2(help,32);
						Mindicator[i].GetComponent<RectTransform>().eulerAngles=new Vector3(0,0,135);
					}
				}

				
			}
		}
	}
	
	void HideMe()
	{
		for(int i = 0; i < Mindicator.Length; i++)
		{
			Mindicator[i].GetComponent<RectTransform>().position = new Vector2(2047,2047);//throw of the screen
		}
	}
	
}
