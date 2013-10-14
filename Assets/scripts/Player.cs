using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public string startingRoom = "";
	
	public InventoryManager inventory;
	public Notification notification;
	public MouseManager mouseManager;

	public GUIStyle basicStyle;
	
	Camera camera;
	
	void Start() 
	{
		camera = Camera.main;
		inventory = new InventoryManager();
		inventory.init(basicStyle);
		notification = new Notification();
		notification.init(basicStyle);
		mouseManager = GetComponent<MouseManager>();
		EventCenter.Instance.onEnablePlayer += this.onEnablePlayer;
	}
	
	void Update() {
		if(Input.GetKeyDown(KeyCode.Q)) {
			 inventory.showInventory = !inventory.showInventory;
			inventory.showDetail = false;
			this.enablePlayer(!inventory.showInventory);
		} else if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) {
			if(notification.showNote) {
				notification.destroy();
			}
		}
	}
	
	void OnGUI()
		{
				mouseManager.drawCursor();
//		Debug.Log("Player/OnGUI, showInventory = " + inventory.showInventory + ", showDetail = " + inventory.showDetail);
				if (inventory.showInventory) {
								inventory.drawInventory();
				} else if (inventory.showDetail) {
								inventory.drawDetail();
		} else if(notification.showNote) {
			notification.drawNote();
		}
	}
	
	public void onEnablePlayer (bool enable) {
		enablePlayer(enable);
	}

	public void enablePlayer(bool enable) {
		// Debug.Log ("Player/enablePlayer, disable = " + disable);
		var mouseLook = GetComponent<MouseLook>();
		mouseLook.isEnabled = enable;
		var cameraMouseLook = camera.GetComponent<MouseLook>();
		cameraMouseLook.isEnabled = enable;
		CharacterMotor character = GetComponent<CharacterMotor>();
		character.SetControllable(enable);
	}
}

