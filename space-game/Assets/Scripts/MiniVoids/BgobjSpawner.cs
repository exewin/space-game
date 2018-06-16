using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgobjSpawner : MonoBehaviour 
{

	public GameObject[] bgobjs;
	float timer;
	float timeSpawn;

	void Update () 
	{
		if(timer>timeSpawn)
		{
			Instantiate(bgobjs[Random.Range(0,bgobjs.Length)],new Vector3(Random.Range(-56,-136),0,0),transform.rotation);
			timer=0;
		}
		else
		{
			timer+=Time.deltaTime*1;
			timeSpawn = Random.Range(10,25);
		}
	}
}

