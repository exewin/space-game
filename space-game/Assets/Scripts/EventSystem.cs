using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventSystem : MonoBehaviour 
{
	public AudioSource audioSource;
	
	public GameObject[] UIPortrait;

	
	public bool spawnShield;
	
	public MouseActions msa;
	public KeyboardActions kba;
	public Toughness tn;
	public Movement mv;
	public Shield sp;
	public LevelUper lu;
	
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
	public GameObject[] waves;
	public int curWave;
	
	float betweenWavesTimer;
	bool doNextWave=false;
	

	public bool debugBool;
	
	public KongregateAPIBehaviour kongComp;
	

	void Start()
	{
		
		//checkpoint starting
		if(!debugBool)
			curWave=StaticVars.level;
		
		WaveInt.GetComponent<Text>().text=""+(curWave+1);
		
		//add bonuses when starting from checkpoint
		if(curWave>=10)
		{
			CustomEvent(2);
		}
		else
		{
			lu.LevelUp(0);
		}
		if(curWave>=20)
		{
			CustomEvent(1);
		}			
		if(curWave>=30)
		{
			CustomEvent(3);
		}
		if(curWave>=40)
		{
			CustomEvent(1);
		}
		
		lu.PickupExperiencePack(9*curWave);
		
		StartCoroutine(Waiter());
	}
	
	IEnumerator Waiter()
    {
        yield return new WaitForSeconds(3);
		WaveInt.GetComponent<Text>().text=""+(curWave+1);
		audioSource = GetComponent<AudioSource>();
		waves = GetAllChildren.getChildren(gameObject,false,"Wave");
		waves[curWave].SetActive(true);
		timer = 5;
    }
	
	public void CastEvent(int portraitID, string msg, int specEvent, SingleWave thisWave)
	{
		PortraitDisplay(portraitID);
		UIText.GetComponent<Text>().text=msg;
		if(specEvent!=0)
		{
			CustomEvent(specEvent);
		}
		audioSource.Play();
		timer=3;
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
			timer-=Time.deltaTime*1;
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
			SaveLevels();
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
	
	
	void SaveLevels()
	{
		if(PlayerPrefs.GetInt("checkpoint")<curWave)
		{
			PlayerPrefs.SetInt("checkpoint",curWave);
			kongComp.SendLevel(curWave);
		}
	}

	
	public void CustomEvent(int id)
	{
		
		if(id==1) //BoostShip
		{
			tn.maxHp+=125;
			tn.hp=tn.maxHp;
			mv.maxSpeed+=200;
			if(mv.speed<=mv.maxSpeed)
				mv.speed=mv.maxSpeed;
			tn.AdjustUI();
		}
		
		else if(id==2) //Install RcktLaunch
		{
			msa.allowRocketLauncher=true;
		}
		
		else if(id==3) //Install Shield
		{
			spawnShield=true;
			kba.allowShield=true;
			ShieldUI.SetActive(true);
		}
		
		else if(id==4)//switch music
		{
			MusicSwitcher.GetComponent<MusicScript>().curMusic++;
			MusicSwitcher.GetComponent<AudioSource>().clip = MusicSwitcher.GetComponent<MusicScript>().music[MusicSwitcher.GetComponent<MusicScript>().curMusic];
			MusicSwitcher.GetComponent<AudioSource>().Play();
		}
		
		else if(id==5)
		{
			sp.maxShield+=150;
			sp.shieldRegen+=3;
			sp.energy=sp.maxShield;
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
