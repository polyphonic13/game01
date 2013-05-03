using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public InventoryManager inventory;
	
	bool inventoryOpen = false;
	bool inventoryDrawn = false;
	Camera camera;
	
	// Use this for initialization
	void Start () 
	{
		Debug.Log("PLAYER START!");
		camera = Camera.main;
		inventory = new InventoryManager();
		inventory.init();
		//Debug.Log("inventory = " + inventory);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("q")) {
			inventoryOpen = !inventoryOpen;
			DisablePlayer(!inventoryOpen);
			if(!inventoryOpen) { 
				inventoryDrawn = false;
			}
		}
	}
	
	void OnGUI() {
		if(inventoryOpen) {
			//ArrayList items = inventory.GetItems();
			//Debug.Log("items = " + items.Count);
			if(!inventoryDrawn) {
				inventory.DrawInventory();
				inventoryDrawn = true;
			}
		}
	}
	
	void DisablePlayer(bool disable) {
		var mouseLook = GetComponent<MouseLook>();
		mouseLook.isEnabled = disable;
		var cameraMouseLook = camera.GetComponent<MouseLook>();
		cameraMouseLook.isEnabled = disable;
		var character = GetComponent<CharacterMotor>();
		character.SetControllable(disable);
	}
}
