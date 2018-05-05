using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour 
{
	
	[Range(1,100)]
	public GameObject[] prefabs;
	EventSystem EvSys;
	
	void Start()
	{
		EvSys = GameObject.Find("EventSystem").GetComponent<EventSystem>();
	}
	
	void OnDestroy() 
	{
		if(EvSys.spawnExp)
		{
			Instantiate (prefabs[0],transform.position,transform.rotation);
			EvSys.spawnExp=false;
		}
		else
		{
			EvSys.spawnExp=true;
			if(Random.Range(1,100)<25)
				Instantiate (prefabs[Random.Range(1,6)],transform.position,transform.rotation);
		}
	}
	
}
