using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public InventoryManager inventory;
	
	bool inventoryOpen = false;
	Camera camera;
	
	// Use this for initialization
	void Start () 
	{
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
		}
	}
	
	void OnGUI() {
		if(inventoryOpen) {
			GUI.Box(new Rect(50, 50, Screen.width - 100, Screen.height - 100), "INVENTORY");
			ArrayList items = inventory.GetItems();
			Debug.Log("items = " + items.Count);
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
