using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class Link : MonoBehaviour 
{

	public string Field;

	public void OpenLink()
	{
		Application.OpenURL(Field);
	}

	public void OpenLinkJS()
	{
		Application.ExternalEval("window.open('"+Field+"');");
	}

	public void OpenLinkJSPlugin()
	{
		#if !UNITY_EDITOR
		openWindow(Field);
		#endif
	}

	[DllImport("__Internal")]
	private static extern void openWindow(string url);

}