using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnResolutionChange : MonoBehaviour 
{

	public static float OnResolution()
	{
		return Screen.width*1f/Screen.height*1f;
	}
	
}
