using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour 
{
	
	public float hostileness;
	private float hostilenessR = 0.0f;
	public GameObject[] meteor;
	[Range(25,100)]
	public int biggity=25;

	void Update () 
	{
		if(hostilenessR>hostileness)
		{
			hostilenessR=0;
			SpawnMeteor();
		}		
	}
	
	void LateUpdate()
	{
		hostilenessR+=Time.deltaTime;
	}
	
	void SpawnMeteor()
	{
		GameObject spawn = Instantiate(meteor[Random.Range(0,meteor.Length-1)],transform.position,transform.rotation);
		int randomness=Random.Range(25,biggity);
		spawn.transform.localScale = new Vector3((float)randomness/50f,(float)randomness/50f, 1);
		spawn.GetComponent<Toughness>().maxHp=randomness*3;
		spawn.GetComponent<Toughness>().hp=randomness*3;
		spawn.GetComponent<Rigidbody2D>().mass=randomness;
		spawn.GetComponent<Meteor>().speed = Random.Range(300*biggity,500*biggity);
		
	}
}
