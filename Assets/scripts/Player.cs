using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	bool inventoryOpen = false;
	Camera camera;
	//InventoryManager inventory;
	
	// Use this for initialization
	void Start () 
	{
		camera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("q")) {
			inventoryOpen = !inventoryOpen;
			disablePlayer(!inventoryOpen);
		}
	}
	
	void OnGUI() {
		if(inventoryOpen) {
			GUI.Box(new Rect(50, 50, Screen.width - 100, Screen.height - 100), "INVENTORY");
		}
	}
	
	void disablePlayer(bool disable) {
		var mouseLook = GetComponent<MouseLook>();
		mouseLook.isEnabled = disable;
		var cameraMouseLook = camera.GetComponent<MouseLook>();
		cameraMouseLook.isEnabled = disable;
		var character = GetComponent<CharacterMotor>();
		character.SetControllable(disable);
	}
}
