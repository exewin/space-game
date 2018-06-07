using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleWave : MonoBehaviour 
{

	public int numOfObjs;
	public GameObject wave;
	public GameObject dangerZone;
	public EventSystem msg;
	
	[System.Serializable]
	public class dial
	{
		public enum character : int { Willis=0, Technician=1, Alice=2, Zotron=3}
		public character who;
		[TextArea(2,4)]
		public string text;
		public int venue;
	}
	
	void Start()
	{
		dangerZone.SetActive(false);
		numOfObjs=GetAllChildren.getChildren(wave,false,"Enemy").Length;
	}
	
	public dial[] boxes;
	
}