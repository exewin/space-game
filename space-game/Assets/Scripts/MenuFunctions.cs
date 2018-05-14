using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MenuFunctions : MonoBehaviour 
{
	
	public GameObject[] menus;
	

	public void ExitGame()
	{
		Debug.Log("Exit game");
		Application.Quit();
	}
	
	public void StartGame()
	{
		SceneManager.LoadScene("Game");
	}
	
	public void ActiveSubmenu(int id)
	{
		for(int i = 0; i < menus.Length; i++)
		{
			menus[i].SetActive(false);
		}
		menus[id].SetActive(true);
	}
	
	public void SetResolution(int resId)
	{
		if(resId==1)
			Screen.SetResolution(1280,720,Screen.fullScreen);
		else if(resId==2)
			Screen.SetResolution(1366,768,Screen.fullScreen);		
		else if(resId==3)
			Screen.SetResolution(1600,900,Screen.fullScreen);		
		else if(resId==4)
			Screen.SetResolution(1920,1080,Screen.fullScreen);
	}
	
	public void SetFullScreen(GameObject x)
	{
		Screen.fullScreen=!Screen.fullScreen;
		if(Screen.fullScreen)
			x.GetComponent<Text>().text="X";
		else
			x.GetComponent<Text>().text="";
	}
	
	public void OpenLink(string link)
	{
		Application.OpenURL(link);
	}
}
