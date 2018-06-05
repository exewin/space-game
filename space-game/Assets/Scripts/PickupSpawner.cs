using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour 
{
	
	public GameObject[] prefabs;
	EventSystem EvSys;
	public int exp;
	
	void Start()
	{
		EvSys = GameObject.Find("EventSystem").GetComponent<EventSystem>();
	}
	
	void SpawnPickup() 
	{
		//spawn HP
		if(Random.Range(1,100)<35)
				Instantiate (prefabs[0],transform.position+new Vector3(Random.Range(-2,2),Random.Range(-2,2),0),transform.rotation);
			
		//spawn SP
		if(EvSys.spawnShield)
		{
			if(Random.Range(1,100)<30)
				Instantiate (prefabs[1],transform.position+new Vector3(Random.Range(-2,2),Random.Range(-2,2),0),transform.rotation);
		}

		//spawn ExpPak
		GameObject expPack = Instantiate (prefabs[2],transform.position+new Vector3(Random.Range(-2,2),Random.Range(-2,2),0),transform.rotation);
		expPack.GetComponent<Pickup>().multiplier=exp;

			
		//spawn rnd bonus
		if(Random.Range(1,100)<25)
			Instantiate (prefabs[Random.Range(3,prefabs.Length)],transform.position+new Vector3(Random.Range(-2,2),Random.Range(-2,2),0),transform.rotation);

	}
	
}
