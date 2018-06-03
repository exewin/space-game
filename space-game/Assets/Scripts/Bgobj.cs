using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bgobj : MonoBehaviour 
{

	public bool randomColor;
	public bool randomScale;
	public bool randomRot;
	public int highOrder;
	
	float scale = 1;

	void Start() 
	{
		if(randomColor)
			GetComponent<SpriteRenderer>().color = new Color(Random.Range(0,0.5f),Random.Range(0,0.5f),Random.Range(0,0.5f),1);
		
		if(randomScale)
		{
			scale = Random.Range(0.5f,3f);
			transform.localScale = new Vector3(scale,scale,scale);
			GetComponent<SpriteRenderer>().sortingOrder = (int)(-200+(scale*16))+highOrder;
			if(highOrder!=0)
			{
				GameObject[] childs;
				childs=GetAllChildren.getChildren(gameObject);
				for(int i=0;i<childs.Length;i++)
				{
					childs[i].GetComponent<SpriteRenderer>().sortingOrder = (int)(-200+(scale*16))+highOrder-1-i;
				}
			}
		}
		
		if(randomRot)
		{
			Quaternion rotation = Quaternion.Euler(0, 0, Random.Range(0,360f));
			transform.rotation = rotation;
		}
	}
	
	void Update()
	{
		if(randomScale)
			transform.Translate(0,-scale*Time.deltaTime,0,Space.World);
	}
}
