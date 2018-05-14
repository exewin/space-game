using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowedModeCheck : MonoBehaviour 
{

	void Start () 
	{
		if(Screen.fullScreen)
			GetComponent<Text>().text="X";
		else
			GetComponent<Text>().text="";
	}

}
