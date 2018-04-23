using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedColor : MonoBehaviour
{

	float kolor;
	bool mode;

	void Update () 
	{
		if(kolor > 0.95)
			mode=false;
		if(kolor < 0.05)
			mode=true;
		
		if(mode)
			kolor+=Time.deltaTime*0.3f;
		else
			kolor-=Time.deltaTime*0.3f;
		
		GetComponent<SpriteRenderer>().color=new Color(1, 0, 0, kolor);
	}
}
