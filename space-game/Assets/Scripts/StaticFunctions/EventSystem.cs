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
	public GameObject UIPortrait;
	public GameObject ShieldUI;
	
	public bool spawnShield;
	
	public MouseActions msa;
	public KeyboardActions kba;
	public Toughness tn;
	
	public GameObject MusicSwitcher;
	public GameObject Canvas;
	public GameObject VictoryScreen;
	
	void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}
	
	public void CastEvent(int id)
	{
		UIPortrait.SetActive(true);
		UIText.GetComponent<Text>().text=msgs[id];
		if(specialEvents[id]!=0)
		{
			CustomEvent(specialEvents[id]); //bring the silence
		}
		if(msgs[id]!="")
		{
			audioSource.PlayOneShot(msgSound);	
		}
		else
			UIPortrait.SetActive(false);
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
			spawnShield=true;
			kba.allowShield=true;
			ShieldUI.SetActive(true);
		}
		if(id==4)
		{
			tn.maxHp+=25;
			tn.hp=tn.maxHp;
			tn.AdjustUI();
		}
		if(id==5)
		{
			EndGame();
			
		}
		if(id==6)//switch music
		{
			MusicSwitcher.GetComponent<MusicScript>().curMusic++;
			MusicSwitcher.GetComponent<AudioSource>().clip = MusicSwitcher.GetComponent<MusicScript>().music[MusicSwitcher.GetComponent<MusicScript>().curMusic];
			MusicSwitcher.GetComponent<AudioSource>().Play();
		}
	}
	
	public void EndGame()
	{
		Canvas.GetComponent<Pause>().endGame=true;
		VictoryScreen.SetActive(true);
	}
}
