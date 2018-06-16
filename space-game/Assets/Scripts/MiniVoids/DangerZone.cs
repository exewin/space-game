using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour 
{
	[HideInInspector]
	public bool enabling;
	float alpha;
	public GameObject dangerZoneText;
	void OnEnable()
	{
		enabling=true;
		alpha=0f;
	}
	
	void Update()
	{
		if(enabling)	
		{
			if(alpha<0.25f)
			{
				alpha+=Time.deltaTime*0.25f;
				GetComponent<SpriteRenderer>().color=new Color(1,0.2f,0,alpha);
				dangerZoneText.GetComponent<TextMesh>().color=new Color(1,0.1f,0,alpha*2);
			}
		}
		else
		{
			if(alpha>0f)
			{
				alpha-=Time.deltaTime*0.5f;
				GetComponent<SpriteRenderer>().color=new Color(1,0.2f,0,alpha);
				dangerZoneText.GetComponent<TextMesh>().color=new Color(1,0.1f,0,alpha*2);
			}
			else
				gameObject.SetActive(false);
			
		}
	}
	
	
}
