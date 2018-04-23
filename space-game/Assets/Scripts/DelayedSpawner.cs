using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedSpawner : MonoBehaviour 
{
	public GameObject[] spwnObj;
	public float[] timers;
	public float randomness;
	int cur;
	/*
	example:
	timers (2,1,2)
	spwnObj (obj1, obj2, obj3)
	
	>wait 2 sec
	>spawn obj1
	>wait 1 sec
	>spawn obj2
	>wait 2 sec
	>spawn obj3
	*/
	
	void Update()
	{
		if(cur<timers.Length)
		{
			timers[cur]-=Time.deltaTime*1;
			if(timers[cur]<=0)
			{
				Instantiate(spwnObj[cur],transform.position-new Vector3(Random.Range(-randomness,randomness),Random.Range(-randomness,randomness),0),transform.rotation);
				cur++;
			}
		}
		else
			Destroy(this);
	}
}
