using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAllChildren : MonoBehaviour 
{

	//recursive for children of children etc.
	public static GameObject[] getChildren(GameObject parent, bool recursive = false, string childTag="")
	{
		List<GameObject> items = new List<GameObject>();
		for (int i = 0; i < parent.transform.childCount; i++)
		{
			if(childTag==""||childTag==parent.transform.GetChild(i).gameObject.tag)
			{
				items.Add(parent.transform.GetChild(i).gameObject);
				if (recursive) 
				{ // set true to go through the hiearchy.
					items.AddRange(getChildren(parent.transform.GetChild(i).gameObject,recursive,childTag));
				}
			}
		}
		return items.ToArray();
	}
}
