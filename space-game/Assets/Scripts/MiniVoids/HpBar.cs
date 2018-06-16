using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBar : MonoBehaviour 
{

	public GameObject target;
	public GameObject myInt;
	RectTransform rect;
	
	void Start()
	{
		rect = GetComponent<RectTransform>();
	}

	void Update () 
	{
		if(target)
		{
			Vector2 positionOnScreen = Camera.main.WorldToScreenPoint (target.transform.position);
			rect.position = positionOnScreen + new Vector2(0,30);
		}
		else if(rect.position.x != -40)
		{
			rect.position = new Vector2(-40,-40); //throw of the screen
		}
	}
	

	public void UpdateInt ()
	{
		myInt.transform.localScale = new Vector3((float)target.GetComponent<Toughness>().hp/target.GetComponent<Toughness>().maxHp,1,1);
	}
}
