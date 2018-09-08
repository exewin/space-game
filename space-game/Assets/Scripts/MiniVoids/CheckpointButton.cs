using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointButton : MonoBehaviour 
{
	
	public int level;


	void Start () 
	{
		if(PlayerPrefs.HasKey("checkpoint"))
			if(PlayerPrefs.GetInt("checkpoint")>=level)
			{
				GetComponent<Button>().interactable=true;
				return;
			}

		GetComponent<Button>().interactable=false;
	}
	

}
