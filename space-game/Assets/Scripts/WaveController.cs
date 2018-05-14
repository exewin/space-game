using System.Collections;
using UnityEngine;

public class WaveController : MonoBehaviour 
{
	public int curEvent = -1;
	public int curWave = 0;
	public int numOfObjs;
	GameObject [] wave;
	public GameObject dangerZone;
	public EventSystem venue;
	
	public int[] miniEvents;
	
	void Start()
	{
		dangerZone.SetActive(false);
		wave=GetAllChildren.getChildren(gameObject);
		StartCoroutine(Waiter(3));
	}
	
	
	void NextEvent()
	{
		if(miniEvents.Length==curEvent)
		{
			Debug.Log("endGame");
		}
		else
		{
			curEvent++;
			//wave
			if(miniEvents[curEvent]==0)
			{
				dangerZone.GetComponent<DangerZone>().enabling=false;
				curWave++;
				wave[curWave].SetActive(true);
				numOfObjs=GetAllChildren.getChildren(wave[curWave],false,"Enemy").Length;
				venue.CastEvent(miniEvents[curEvent]);
			}
			//text
			else
			{
				venue.CastEvent(miniEvents[curEvent]);
				StartCoroutine(Waiter(5));
			}
		}
	}
	
	public void Reduce()
	{
		numOfObjs=GetAllChildren.getChildren(wave[curWave],false,"Enemy").Length-1;
		if(numOfObjs<=0)
		{
			DestroyMeteors();
			if(curWave!=19)
			{
				dangerZone.SetActive(true);
			}
			Destroy(wave[curWave]);
			StartCoroutine(Waiter(5));
		}
	}	
	
	IEnumerator Waiter (int secs)
	{
		yield return new WaitForSeconds(secs);
		NextEvent();
	}
	
	void EndGame()
	{
		Debug.Log("victory");
	}
	
	void DestroyMeteors()
	{
		GameObject[] meteors = GameObject.FindGameObjectsWithTag("Meteor");
		foreach (GameObject meteor in meteors)
        {
			meteor.GetComponent<Toughness>().Annihilation();
		}
	}
}
