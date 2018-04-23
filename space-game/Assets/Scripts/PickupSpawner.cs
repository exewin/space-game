using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour 
{
	
	[Range(1,100)]
	public byte[] percentage;
	public GameObject[] prefabs;
	
	void OnDestroy() 
	{
		for(int i = 0; i < Mathf.Min(percentage.Length,prefabs.Length); i++)
		{
			if(Random.Range(1,100) < percentage[i])
			{
				Instantiate (prefabs[i],transform.position,transform.rotation);
				break;
			}
		}
	}
	
}
