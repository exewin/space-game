using System.Collections;
using UnityEngine;

public class WaveController : MonoBehaviour 
{
	public int curWave = -1;
	public int numOfObjs;
	public GameObject [] wave;
	
	void Start()
	{
		wave=GetAllChildren.getChildren(gameObject);
		NextWave();
	}
	
	void KillWave()
	{
		//wave[curWave].SetActive(false);
		StartCoroutine(Waiter());
	}
	
	void NextWave()
	{
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
		yield return new WaitForSeconds(3);
		NextWave();
	}
	
	void EndGame()
	{
		Debug.Log("victory");
	}
}
