using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperiencePackInt : MonoBehaviour
{
	
	public Pickup parent;

	void Start()
	{
		GetComponent<TextMesh>().text=""+parent.multiplier;
	}

}
