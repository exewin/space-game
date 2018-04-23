using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour 
{

	public static bool paused;
	
	public GameObject pauseMenuUI;
	
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Pause))
		{
			if(paused)
			{
				ResumeGame();
			}
			else
			{
				PauseGame();
			}
		}
	}
	
	public void ResumeGame()
	{
		pauseMenuUI.SetActive(false);
		Time.timeScale=1f;
		paused=false;
	}
	
	void PauseGame()
	{
		pauseMenuUI.SetActive(true);
		Time.timeScale=0f;
		paused=true;
	}
	
	public void LoadMenu()
	{
		Time.timeScale=1f;
		//SceneManager.LoadScene("menu");
		Debug.Log("menu");
	}
	
	public void QuitGame()
	{
		Debug.Log("quit");
		Application.Quit();
	}

}
