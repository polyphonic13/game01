using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	bool inventoryOpen = false;
	//InventoryManager inventory;
	
	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("q")) {
			Debug.Log("Player/Update, q pressed");
			inventoryOpen = !inventoryOpen;
		}
	}
	
	void OnGui() {
		Debug.Log("Player/OnGui, inventoryOpen = " + inventoryOpen);
		if(inventoryOpen) {
			GUI.Box(new Rect(0, 0, Screen.width/2, Screen.height/2), "HELLO INVENTORY!");
		}
	}
	
}
