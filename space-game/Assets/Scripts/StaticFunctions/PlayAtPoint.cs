using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAtPoint : MonoBehaviour
 {

	public AudioClip[] sound;
	void Start () 
	{
		if(sound.Length==1)
			AudioSource.PlayClipAtPoint(sound[0],new Vector3(4,0,0));
		else
			AudioSource.PlayClipAtPoint(sound[Random.Range(0,sound.Length-1)],new Vector3(4,0,0));
	}

}
