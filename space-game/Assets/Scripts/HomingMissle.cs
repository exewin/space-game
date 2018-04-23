using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissle : MonoBehaviour 
{

	Transform target;

	public float speed = 5f;
	public float followTime; //seconds

	void Start () 
	{
		if(GameObject.FindGameObjectWithTag("Player"))
			target=GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	void Update()
	{
		if(target && followTime>=0)
		{
			Vector3 vectorToTarget = target.transform.position - transform.position;
			float angle = (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg) - 90;
			Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
		}
		
		if(followTime>=0)
			followTime-=Time.deltaTime*1;
	}
}
