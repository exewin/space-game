using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardActions : MonoBehaviour 
{

	public string[] inputs;
	void Start ()
	{
		gameObject.SendMessage("GetInputs", inputs);
	}
	void FixedUpdate () 
	{
		for(int i=0;i<4;i++)
		{
			if(Input.GetKey(inputs[i]))
			{
				gameObject.SendMessage("GetInput", i+1);
			}	
		}
		
	}
	
	void Update()
	{
		if(Input.GetKey(KeyCode.Space))
		{
			gameObject.SendMessage("ShieldMe",1);
		}
		else if(Input.GetKeyUp(KeyCode.Space))
		{
			gameObject.SendMessage("ShieldMe",2);
		}
	}
}
