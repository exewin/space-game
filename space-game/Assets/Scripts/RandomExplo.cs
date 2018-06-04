using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomExplo : MonoBehaviour 
{

	public GameObject[] explosions;
	GameObject explo;
	
	void Start () 
	{
		explo = Instantiate(explosions[Random.Range(0,explosions.Length)], transform.position,transform.rotation);
		Destroy(explo,1.3f);
		
	}
	
	
	float clr = 1;
	
	void Update()
	{
		if(explo)
		{
			clr -=Time.deltaTime*0.4f;
			explo.GetComponent<SpriteRenderer>().color=new Color(1,1,1,clr);
		}
		else
			Destroy(gameObject);
	}
	

}
