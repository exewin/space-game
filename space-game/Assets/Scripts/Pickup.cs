using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour
{
		
	public float speed; 
	public byte type;

	//0 for instant
	public float bonusTime;
	
	public float multiplier; 
	
	public AudioClip sound;
	
	void OnDisable()
	{
		Destroy(gameObject);
	}
	
	void Update()
    {
		transform.Translate(0,speed*Time.deltaTime,0);
    }
	
	void OnTriggerEnter2D(Collider2D player)
	{
		if(player.tag == "Player")
		{
			StartCoroutine(Boost(player));
		}
	}
	
	IEnumerator Boost (Collider2D player)
	{
		AudioSource.PlayClipAtPoint(sound, new Vector3(0,0,0));
		GameObject ship = player.gameObject;
		if(type==0)
			ship.SendMessage("PickupR",(int)multiplier);
		else if(type==1)
			ship.SendMessage("PickupSP",1.5f);
		else if(type==2)
			ship.SendMessage("PickupRF",2);
		else if(type==3)
			ship.SendMessage("PickupW",true);
		else if(type==4)
			ship.SendMessage("PickupL",true);
		else if(type==5)
			ship.SendMessage("PickupEB",multiplier);
		
		if(bonusTime!=0)
		{
			GetComponent<SpriteRenderer>().enabled = false;
			GetComponent<Collider2D>().enabled = false;
			yield return new WaitForSeconds(bonusTime);
			
			if(type==1)
				ship.SendMessage("PickupSP",1);
			else if(type==2)
				ship.SendMessage("PickupRF",1);
			else if(type==3)
				ship.SendMessage("PickupW",false);
			else if(type==4)
				ship.SendMessage("PickupL",false);
			else if(type==5)
				ship.SendMessage("PickupEB",1/multiplier);
		}
		
		Destroy(gameObject);
	}
	
	
}