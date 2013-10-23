using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public string startingRoom = "";
	
	public InventoryManager inventory;
	public Notification notification;
	public Menu menu;
	
	public GUIStyle basicStyle;
	
	Camera camera;
	
	void Awake() {
		camera = Camera.main;
		inventory = new InventoryManager();
		inventory.init(basicStyle);
		notification = new Notification();
		notification.init(basicStyle);
		menu = new Menu();
		menu.init(basicStyle);
		menu.showMenu = true;
		EventCenter.Instance.onEnablePlayer += this.onEnablePlayer;
	}
	
	void Update() {
		if(Input.GetKeyDown(KeyCode.Q)) {
			inventory.showInventory = !inventory.showInventory;
			inventory.showDetail = false;
		} else if(Input.GetKeyDown(KeyCode.M)) {
			menu.showMenu = !menu.showMenu;
		} else if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) {
			inventory.showDetail = false;
			inventory.showInventory = false;
			menu.showMenu = false;
			if(notification.showNote) {
				notification.destroy();
			}
		}
		if(!inventory.showDetail && !inventory.showInventory && !menu.showMenu && !notification.showNote) {
			enablePlayer(true);
		}
	}
	
	void OnGUI () {
		MouseManager.Instance.drawCursor ();
//		Debug.Log("Player/OnGUI, showInventory = " + inventory.showInventory + ", showDetail = " + inventory.showDetail);
		if (inventory.showInventory) {
			inventory.drawSummary ();
			if(notification.showNote) {
				EventCenter.Instance.removeNote();
			}
		} else if (inventory.showDetail) {
			inventory.drawDetail ();
		} else if(menu.showMenu) {
			menu.draw();
		} else if (notification.showNote) {
			notification.drawNote ();
		} else if (inventory.houseKeepingNeeded) {
			inventory.houseKeeping ();
		}
	}
	
	public void onEnablePlayer(bool enable) {
		enablePlayer(enable);
	}

	public void enablePlayer(bool enable) {
		// Debug.Log("Player/enablePlayer, disable = " + disable);
		var mouseLook = GetComponent<MouseLook>();
		mouseLook.isEnabled = enable;
		var cameraMouseLook = camera.GetComponent<MouseLook>();
		cameraMouseLook.isEnabled = enable;
		CharacterMotor character = GetComponent<CharacterMotor>();
		character.SetControllable(enable);
		Screen.lockCursor = enable;
		
		if(enable) {
			inventory.showDetail = false;
			inventory.showInventory = false;
			menu.showMenu = false;
		}
	}
}

