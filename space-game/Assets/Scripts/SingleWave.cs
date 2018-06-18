using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleWave : MonoBehaviour 
{

	public int numOfObjs;
	public GameObject wave;
	public GameObject dangerZone;
	public EventSystem venue;
	int curDial;
	
	public bool lastWave;
	
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
		wave.SetActive(false);
		curDial=0;
		dangerZone.SetActive(true);
		numOfObjs=GetAllChildren.getChildren(wave,false,"Enemy").Length;
		ContinuePlot();
	}
	
	public void ContinuePlot()
	{
		if(curDial<=boxes.Length-1)
		{
			venue.CastEvent((int)boxes[curDial].who,boxes[curDial].text,boxes[curDial].specEvent,this);
			curDial++;
		}
		else
		{
			dangerZone.SetActive(false);
			venue.RemoveEvent();
			wave.SetActive(true);
			venue.gameObject.SendMessage("CallMe",0);
			numOfObjs=GetAllChildren.getChildren(wave,false,"Enemy").Length;
			
		}
	}
	
	
	public void Reduce()
	{
		numOfObjs=GetAllChildren.getChildren(wave,false,"Enemy").Length-1;
		if(numOfObjs<=0)
		{
			if(!lastWave)
				dangerZone.SetActive(true);
			
			DestroyMeteors();
			venue.gameObject.SendMessage("HideMe",0);
			venue.NextWave();
			Destroy(gameObject);
			
		}
	}	
	
	
	void DestroyMeteors()
	{
		GameObject[] meteors = GameObject.FindGameObjectsWithTag("Meteor");
		foreach (GameObject meteor in meteors)
        {
			meteor.GetComponent<Toughness>().killAfter=true;
			meteor.GetComponent<Toughness>().Annihilation();
		}
	}
	
	
	
}