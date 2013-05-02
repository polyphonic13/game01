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
			inventoryOpen = !inventoryOpen;
		}
	}
	
	void OnGUI() {
		if(inventoryOpen) {
			GUI.Box(new Rect(0, 0, Screen.width/2, Screen.height/2), "HELLO INVENTORY!");
			disablePlayer(true);
		} else {
			var mouseLook = GetComponent<MouseLook>();
			disablePlayer(false);
		}
	}
	
	void disablePlayer(bool disabled) {
		var mouseLook = GetHashCode<MouseLook>();
		mouseLook.isEnabled = disabled;
		//var character = GetComponent<CharacterMotor>();
		//character.SetControllable(!disabled);
	}
}
