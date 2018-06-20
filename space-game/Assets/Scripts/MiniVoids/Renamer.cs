using UnityEngine.UI;
using UnityEngine;

public class Renamer : MonoBehaviour 
{


	void Start () 
	{
		gameObject.GetComponent<Text>().text = StaticVars.playName;
	}
	

}
