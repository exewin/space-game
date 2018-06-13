using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonRotation : MonoBehaviour {


	public float speed;
	public float angle;
	public bool flwPlyr;
	Transform target;
	
	
	bool mode;

	void Start () 
	{
		if(flwPlyr)
			if(GameObject.FindGameObjectWithTag("Player"))
				target=GameObject.FindGameObjectWithTag("Player").transform;
		if(gameObject.tag=="MeteorSpawner")
		{
			target=GameObject.FindGameObjectWithTag("MeteorAIM").transform;
		}
	}
	
	void Update () 
	{
		if(flwPlyr)
		{
			if(target)
			{
				Vector3 vectorToTarget = target.transform.position - transform.position;
				float angle = (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg) - 90;
				Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
				transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 50);
			}
		}
		else
		{
			if(angle==0)
			{
				transform.Rotate(0,0,speed*Time.deltaTime);
			}
			else
			{
				if(transform.eulerAngles.z<180-angle)
					mode=true;
				if(transform.eulerAngles.z>180+angle)
					mode=false;
				
				if(mode)
					transform.Rotate(0,0,speed*Time.deltaTime);
				else
					transform.Rotate(0,0,-speed*Time.deltaTime);
			}
		}
	}
}
