using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUper : MonoBehaviour 
{
	public Weapons[] WeaponsPresets;
	void Start ()
	{
		Destroy(GetComponent<Weapons>());
		Weapons wpns = gameObject.AddComponent<Weapons>() as Weapons;
		wpns.Wpns = WeaponsPresets[0].Wpns;
	}
}
