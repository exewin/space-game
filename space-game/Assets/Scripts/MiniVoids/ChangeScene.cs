using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
	public float delay;
	bool mode=true;
	void Start()
	{
		GetComponent<UnityEngine.Video.VideoPlayer>().targetCameraAlpha=.0f;
		StartCoroutine(LoadLevelAfterDelay(delay));
	}

	IEnumerator LoadLevelAfterDelay(float delay)
	{
		yield return new WaitForSeconds(delay*0.9f);
		mode=false;
		GetComponent<UnityEngine.Video.VideoPlayer>().targetCameraAlpha=1;
		yield return new WaitForSeconds(delay*0.2f);
		SceneManager.LoadScene("Menu");
	}
	
	void Update()
	{
		if(mode)
			GetComponent<UnityEngine.Video.VideoPlayer>().targetCameraAlpha+=Time.deltaTime*2;
		else
			GetComponent<UnityEngine.Video.VideoPlayer>().targetCameraAlpha-=Time.deltaTime*4;
	}
}