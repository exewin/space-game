using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseActions : MonoBehaviour
{
	public bool allowLaser;
	public Transform rocketLauncher;
	float prop;
	
	public float speed = 1.0F;
    private float startTime;
    private float journeyLength;
	
	void Start()
	{
		prop=OnResolutionChange.OnResolution();
	}
	
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
				gameObject.SendMessage("Shoot",2);
			}
		}
		

		Vector2 positionOnScreen = Camera.main.WorldToViewportPoint (rocketLauncher.position);
		Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
		mouseOnScreen.x *= prop;
		positionOnScreen.x *= prop;
		float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
		if(Mathf.Abs(rocketLauncher.rotation.z)<0.7)
		{
			rocketLauncher.rotation = Quaternion.Lerp(rocketLauncher.rotation, Quaternion.Euler (new Vector3(0f,0f,angle+90)), 0.05f);
		}
		else if(rocketLauncher.rotation.z>0.7)
		{
			Debug.Log("Er1");
			rocketLauncher.rotation = Quaternion.Euler (new Vector3(0f,0f,88.8f));
		}
		else if(rocketLauncher.rotation.z<-0.7)
		{
			Debug.Log("Er2");
			rocketLauncher.rotation = Quaternion.Euler (new Vector3(0f,0f,-88.8f));
		}
	}
	
	float AngleBetweenTwoPoints(Vector2 a, Vector2 b) 
	{
		return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
	}
	
	void PickupL(bool mode)
	{
		allowLaser=mode;
	}
	
}