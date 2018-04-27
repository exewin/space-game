using System.Collections;
using UnityEngine;

public class WaveController : MonoBehaviour 
{
	public int curWave = -1;
	public int numOfObjs;
	public GameObject [] wave;
	public GameObject dangerZone;
	
	void Start()
	{
		dangerZone.SetActive(false);
		wave=GetAllChildren.getChildren(gameObject);
		NextWave();
	}
	
	void KillWave()
	{
		dangerZone.SetActive(true);
		StartCoroutine(Waiter());
	}
	
	void NextWave()
	{
		dangerZone.GetComponent<DangerZone>().enabling=false;
		curWave++;
		if(curWave>=wave.Length)
			EndGame();
		else
		{
			wave[curWave].SetActive(true);
			numOfObjs=GetAllChildren.getChildren(wave[curWave],false,"Enemy").Length;
		}
	}
	
	public void Reduce()
	{
		numOfObjs--;
		if(numOfObjs<=0)
		{
			KillWave();
		}
	}	
	
	IEnumerator Waiter ()
	{
		yield return new WaitForSeconds(5);
		NextWave();
	}
	
	void EndGame()
	{
		Debug.Log("victory");
	}
}
