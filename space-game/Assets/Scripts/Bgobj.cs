using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bgobj : MonoBehaviour 
{

	public bool randomColor;
	public bool randomScale;
	public bool randomRot;
	
	float scale = 1;

	void Start() 
	{
		if(randomColor)
			GetComponent<SpriteRenderer>().color = new Color(Random.Range(0,.7f),Random.Range(0,.7f),Random.Range(0,.7f),1);
		
		if(randomScale)
		{
			scale = Random.Range(0.5f,3f);
			transform.localScale = new Vector3(scale,scale,scale);
			GetComponent<SpriteRenderer>().sortingOrder = (int)(-200+(scale*16));
		}
		
		if(randomRot)
		{
			Quaternion rotation = Quaternion.Euler(0, 0, Random.Range(0,360f));
			transform.rotation = rotation;
		}
	}
	
	void Update()
	{
		transform.Translate(0,-scale*Time.deltaTime,0,Space.World);
	}
}
