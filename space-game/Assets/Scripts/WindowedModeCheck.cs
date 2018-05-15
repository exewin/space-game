using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowedModeCheck : MonoBehaviour 
{

	void Awake() 
	{
		if(Screen.fullScreen)
			GetComponent<Text>().text="";
		else
			GetComponent<Text>().text="X";
	}

}
