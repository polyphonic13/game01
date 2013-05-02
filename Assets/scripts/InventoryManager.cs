using UnityEngine;
using System.Collections;

public class InventoryManager {
	
	ArrayList items;
	public bool showItems = false;
	
	void OnGUI () {
		if(showItems) {
			Debug.Log("InventoryManager/OnGUI, showItems = " + showItems);
	//		GUI.Box (new Rect (0,0,100,50), "Top-left");
	//		GUI.Box (new Rect (Screen.width - 100,0,100,50), "Top-right");
	//		GUI.Box (new Rect (0,Screen.height - 50,100,50), "Bottom-left");
	//		GUI.Box (new Rect (Screen.width - 100,Screen.height - 50,100,50), "Bottom-right");
			GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "Inventory Message");
		}
	}
}
