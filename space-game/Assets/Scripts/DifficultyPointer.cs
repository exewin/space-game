using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DifficultyPointer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	
	public string desc;
	public GameObject tooltip;
	
	public void OnPointerEnter(PointerEventData data)
	{
		tooltip.GetComponent<Text>().text=desc;
	}
	
	public void OnPointerExit(PointerEventData data)
	{
		tooltip.GetComponent<Text>().text="";
	}
}
