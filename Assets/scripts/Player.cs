using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public delegate void onEnterRoom(string room);
	public event onEnterRoom roomEntered;
	public string startingRoom = "";
	
	public InventoryManager inventory;
	public Notification notification;
	
	public GUIStyle basicStyle;
	
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
		//this.roomEntered(this.startingRoom);
		//Debug.Log("inventory = " + inventory);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("q")) {
			inventory.showInventory = !inventory.showInventory;
			inventory.showDetail = false;
			this.EnablePlayer(!inventory.showInventory);
			//if(!inventory.showInventory) { 
			//	inventoryDrawn = false;
			//}
		}
	}
	
	void OnGUI() {
		// Debug.Log("Player/OnGUI, showInventory = " + inventory.showInventory + ", showDetail = " + inventory.showDetail);
		if(inventory.showInventory) {
			//ArrayList items = inventory.GetItems();
			//Debug.Log("items = " + items.Count);
			//if(!inventoryDrawn) {
				// Debug.Log("about to draw gui box");
//				GUI.Box(new Rect(50, 50, Screen.width - 100, Screen.height - 100), "INVENTORY");
				inventory.DrawInventory();
				// inventoryDrawn = true;
			//}
		} else if(inventory.showDetail) {
			inventory.DrawDetail();
		} else if(notification.showNote) {
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

	void OnTriggerEnter(Collider tgt) {
		Debug.Log("Player/OnTriggerEnter, tgt = " + tgt);
		var room = tgt.GetComponent<Room>();
		if(room != null && this.roomEntered != null) {
			this.roomEntered(room.roomName);
		}
	}
}
