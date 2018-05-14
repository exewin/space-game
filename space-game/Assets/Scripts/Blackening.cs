﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blackening : MonoBehaviour 
{
	float clr = 1;
	void Update () 
	{
		clr -=Time.deltaTime*1;
		GetComponent<Graphic>().color=new Color(0,0,0,clr);
		if(clr<0)
			Destroy(gameObject);
	}
	
}
