using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAtPoint : MonoBehaviour
 {

	public AudioClip sound;
	void Start () 
	{
		AudioSource.PlayClipAtPoint(sound,new Vector3(4,0,0));
	}

}
