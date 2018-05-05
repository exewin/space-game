using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuFunctions : MonoBehaviour 
{
	
	public void ExitGame()
	{
		Debug.Log("Exit game");
		Application.Quit();
	}
	
	public void StartGame()
	{
		SceneManager.LoadScene("Game");
	}

}
