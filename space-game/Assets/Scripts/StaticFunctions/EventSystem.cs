using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventSystem : MonoBehaviour 
{

	public AudioClip msgSound;
	public AudioClip msgMeteorSound;
	AudioSource audioSource;
	
	[TextArea(1,4)]
	public string[] msgs;
	public int[] specialEvents;
	
	public GameObject dangerZone;
	
	public GameObject UIText;
	public GameObject ShieldUI;
	
	public bool spawnExp;
	
	public MouseActions msa;
	public KeyboardActions kba;
	public Toughness tn;
	
	void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}
	
	public void CastEvent(int id)
	{
		UIText.GetComponent<Text>().text=msgs[id];
		if(specialEvents[id]!=0)
		{
			CustomEvent(specialEvents[id]); //bring the silence
		}
		if(msgs[id]!="")
			audioSource.PlayOneShot(msgSound);	
	}
	
	public void CustomEvent(int id)
	{
		//active dangerZone
		if(id==1)
			dangerZone.SetActive(true);
		if(id==2)
			msa.allowRocketLauncher=true;
		if(id==3)
		{
			kba.allowShield=true;
			ShieldUI.SetActive(true);
		}
		if(id==4)
		{
			tn.maxHp+=25;
			tn.hp=tn.maxHp;
		}
		if(id==5)
		{
			EndGame();
			
		}
	}
	
	public void EndGame()
	{
		Debug.Log("End Game.");
	}
}
