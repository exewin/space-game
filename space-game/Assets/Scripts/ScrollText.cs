using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollText : MonoBehaviour {

	float counter=0;
	[TextArea(2,5)]
	public string text1;
	string text2;
	
	void Awake () 
	{
		counter=0;
	}
	

	void Update () 
	{
		if(text1!=text2)
			counter+=Time.deltaTime*28;
		text2=text1.Substring(0,(int)counter);
		gameObject.GetComponent<Text>().text=text2;
	}
}
