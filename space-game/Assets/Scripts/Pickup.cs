using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour
{
		
	public float speed; 
	public byte type;
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
			AudioSource.PlayClipAtPoint(sound, new Vector3(0,0,0));
			GameObject ship = player.gameObject;
			if(ship)
			{
				//normal Packs
				if(type==0) // Health Pack
				{
					ship.SendMessage("PickupHealthPack",(int)multiplier);
				}
				else if(type==1) // Shield Pack
				{
					ship.SendMessage("PickupShieldPack",(int)multiplier);
				}
				else if(type==2) // Expierience Pak
				{
					ship.SendMessage("PickupExpieriencePack",(int)multiplier);
				}

				//special Packs
				else if(type==3) // Weaponary
				{
					ship.SendMessage("PickupBonus",1);
				}
				else if(type==4) // Laser
				{
					ship.SendMessage("PickupBonus",2);
				}
				else if(type==5) // EngineBoost
				{
					ship.SendMessage("PickupBonus",3);
				}
				else if(type==6) // SuperProjectiles
				{
					ship.SendMessage("PickupBonus",4);
				}
				else if(type==7) //RapidFire
				{
					ship.SendMessage("PickupBonus",5);
				}
			}
			
			Destroy(gameObject);
		}
	}
	

	
}