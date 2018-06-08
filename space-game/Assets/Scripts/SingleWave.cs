using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleWave : MonoBehaviour 
{

	public int numOfObjs;
	public GameObject wave;
	public GameObject dangerZone;
	public WaveController controller;
	public EventSystem venue;
	int curDial;
	
	[System.Serializable]
	public class dial
	{
		public enum character : int { Willis=0, Technician=1, Alice=2, Zotron=3};
		public character who;
		[TextArea(2,4)]
		public string text;
		public int specEvent;
	}
	
	public dial[] boxes;
	
	void Start()
	{
		curDial=0;
		dangerZone.SetActive(true);
		numOfObjs=GetAllChildren.getChildren(wave,false,"Enemy").Length;
		ContinuePlot();
	}
	
	void ContinuePlot()
	{
		if(curDial<=boxes.Length)
		{
			venue.CastEvent((int)boxes[curDial].who,boxes[curDial].text,boxes[curDial].specEvent);
			curDial++;
		}
		else
		{
			dangerZone.SetActive(false);
			wave.SetActive(true);
			numOfObjs=GetAllChildren.getChildren(wave,false,"Enemy").Length;
		}
	}
	
	
	
}