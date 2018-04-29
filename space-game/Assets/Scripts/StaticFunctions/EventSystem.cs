using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventSystem : MonoBehaviour 
{

	public AudioClip msgSound;
	public AudioClip msgMeteorSound;
	
	[TextArea(1,4)]
	public string[] msgs;
	public int[] specialEvents;
	
	public GameObject dangerZone;
	
	public GameObject UIText;
	
	
	public void CastEvent(int id)
	{
		UIText.GetComponent<Text>().text=msgs[id];
		if(specialEvents[id]!=0)
		{
			CustomEvent(specialEvents[id]);
		}
			
	}
	
	public void CustomEvent(int id)
	{
		//active dangerZone
		if(id==1)
			dangerZone.SetActive(true);
	}

}
