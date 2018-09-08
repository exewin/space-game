using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseActions : MonoBehaviour
{
	public bool allowLaser;
	public bool allowRocketLauncher;
	public Transform rocketLauncher;
	
	
	void FixedUpdate () 
	{
		if(Input.GetMouseButton(0) && Input.GetMouseButton(1) && allowLaser)
		{
			gameObject.SendMessage("Shoot",3,SendMessageOptions.RequireReceiver);
		}
		else
		{
			if(Input.GetMouseButton(0))
			{
				gameObject.SendMessage("Shoot",0,SendMessageOptions.RequireReceiver);
			}
			
			if(Input.GetMouseButton(1))
			{
				gameObject.SendMessage("Shoot",1);
			}
			
			if(Input.GetMouseButton(2))
			{
				if(allowRocketLauncher)
					gameObject.SendMessage("Shoot",2);
			}
		}
		
	}
	
	
}