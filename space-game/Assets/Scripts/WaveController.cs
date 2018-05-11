using System.Collections;
using UnityEngine;

public class WaveController : MonoBehaviour 
{
	public int curEvent = -1;
	public int curWave = 0;
	int numOfObjs;
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
	
	public void Reduce()
	{
		numOfObjs--;
		if(numOfObjs<=0)
		{
			dangerZone.SetActive(true);
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
}
