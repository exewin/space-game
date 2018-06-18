using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventSystem : MonoBehaviour 
{

	public AudioClip msgSound;
	public AudioSource audioSource;
	
	[TextArea(1,4)]
	public string[] msgs;
	
	public GameObject[] UIPortrait;

	
	public bool spawnShield;
	
	public MouseActions msa;
	public KeyboardActions kba;
	public Toughness tn;
	
	public GameObject MusicSwitcher;
	public GameObject Canvas;
	public GameObject VictoryScreen;
	public GameObject dangerZone;
	public GameObject UIText;
	public GameObject WaveInt;
	public GameObject ShieldUI;
	
	public PickupsManager pickupsManager;
	
	
	float timer;
	SingleWave wave;
	GameObject[] waves;
	int curWave;
	
	float betweenWavesTimer;
	bool doNextWave=false;
	
	float counter=0;
	string text1;
	string text2;
	
	void Start()
	{
		WaveInt.GetComponent<Text>().text=""+(curWave+1);
		audioSource = GetComponent<AudioSource>();
		waves = GetAllChildren.getChildren(gameObject,false,"Wave");
		waves[curWave].SetActive(true);
		timer = 5;
	}
	
	public void CastEvent(int portraitID, string msg, int specEvent, SingleWave thisWave)
	{
		PortraitDisplay(portraitID);
		counter=0;
		text1=msg;
		if(specEvent!=0)
		{
			CustomEvent(specEvent);
		}
		audioSource.Play();
		timer=2;
		wave=thisWave;
	}
	
	public void NextWave()
	{
		betweenWavesTimer=3;
		pickupsManager.allowTimers=false;
		doNextWave=true;
	}
	
	public void RemoveEvent()
	{
		pickupsManager.allowTimers=true;
		PortraitDisplay(999);
		UIText.GetComponent<Text>().text="";
	}
	
	void Update () 
	{
		if(timer>0)
		{
			if(text1!=text2)
			{
				counter+=Time.deltaTime*40;
				text2=text1.Substring(0,(int)counter);
				UIText.GetComponent<Text>().text=text2;
			}
			else
			{
				timer-=Time.deltaTime*1;
				audioSource.Stop();
				counter=0;
			}
		}
		else
		{
			if(wave)
				wave.ContinuePlot();
		}
		
		if(betweenWavesTimer>0)
		{
			betweenWavesTimer-=Time.deltaTime*1;
		}
		else if(doNextWave)
		{
			curWave++;
			if(curWave>=waves.Length)
			{
				EndGame();
				return;
			}
			waves[curWave].SetActive(true);
			doNextWave=false;
			WaveInt.GetComponent<Text>().text=""+(curWave+1);
		}
	}

	
	public void CustomEvent(int id)
	{
		//active dangerZone - deleted
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
	
	
	public void PortraitDisplay(int index)
	{
		for(int i = 0; i < UIPortrait.Length; i++)
		{
			UIPortrait[i].SetActive(false);
		}
		if(index==999)
			return;
		
		UIPortrait[index].SetActive(true);
	}
	
	public void EndGame()
	{
		Canvas.GetComponent<Pause>().endGame=true;
		VictoryScreen.SetActive(true);
	}
	
}
