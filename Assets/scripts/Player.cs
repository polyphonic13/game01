using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public InventoryManager inventory;
	public Notification notification;
	
	public GUIStyle basicStyle;
	
	bool inventoryOpen = false;
	bool inventoryDrawn = false;
	Camera camera;
	
	// Use this for initialization
	void Start () 
	{
		// Debug.Log("Player/start, basicStyle = " + basicStyle);
		camera = Camera.main;
		inventory = new InventoryManager();
		inventory.init(basicStyle);
		notification = new Notification();
		notification.init(basicStyle);
		//Debug.Log("inventory = " + inventory);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("q")) {
			inventoryOpen = !inventoryOpen;
			this.EnablePlayer(!inventoryOpen);
			if(!inventoryOpen) { 
				inventoryDrawn = false;
			}
		}
	}
	
	void OnGUI() {
		if(inventoryOpen) {
			//ArrayList items = inventory.GetItems();
			//Debug.Log("items = " + items.Count);
			//if(!inventoryDrawn) {
				// Debug.Log("about to draw gui box");
//				GUI.Box(new Rect(50, 50, Screen.width - 100, Screen.height - 100), "INVENTORY");
				inventory.DrawInventory();
				inventoryDrawn = true;
			//}
		} else if(notification.hasNote) {
			notification.DrawNote();
		}
	}
	
	public void EnablePlayer(bool disable) {
		Debug.Log ("Player/DisablePlayer, disable = " + disable);
		var mouseLook = GetComponent<MouseLook>();
		mouseLook.isEnabled = disable;
		var cameraMouseLook = camera.GetComponent<MouseLook>();
		cameraMouseLook.isEnabled = disable;
		var character = GetComponent<CharacterMotor>();
		character.SetControllable(disable);
	}
}
