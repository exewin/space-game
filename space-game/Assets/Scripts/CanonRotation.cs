using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonRotation : MonoBehaviour {

	public float speed;
	public float angle;
	
	bool mode;

	void Update () 
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
