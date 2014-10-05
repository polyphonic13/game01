using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public string startingRoom = "";

	public Breadcrumb breadcrumb;

	public InventoryManager inventory;
	public Notification notification;
	public Menu menu;
	
	public GUIStyle basicStyle;

	private const float SIGNIFICANT_DISTANCE_CHANGE = 2f;
	private Vector3 _lastPosition;

	private Camera camera;

	private PlayerMeshController headController;

	void Awake() {
		camera = Camera.main;
		_lastPosition = camera.transform.position;
		inventory = new InventoryManager();
		inventory.init(basicStyle);
		notification = new Notification();
		notification.init ();
		menu = new Menu();
		menu.init ();
		menu.show = true;
		EventCenter eventCenter = EventCenter.Instance;
		eventCenter.onEnablePlayer += this.onEnablePlayer;
		eventCenter.onMouseSensitivityChange += this.onMouseSensitivityChange;
		headController = GetComponent<PlayerMeshController> ();
	}
	
	void Update() {
		_checkPositionForChange();
		if(Input.GetKeyDown(KeyCode.Q)) {
			inventory.showInventory = !inventory.showInventory;
			inventory.showDetail = false;
		} else if(Input.GetKeyDown(KeyCode.X) && inventory.isItemEquipped) {
			inventory.dropItem();
		} else if(Input.GetKeyDown(KeyCode.M)) {
			menu.show = !menu.show;
			Debug.Log("M pressed, menu.show now = " + menu.show);
		} else if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) {
			inventory.showDetail = false;
			inventory.showInventory = false;
			menu.show = false;
			if(notification.show) {
				notification.destroy();
			}
		}
		if (!inventory.showDetail && !inventory.showInventory && !menu.show && !notification.show) {
			enablePlayer (true);
		} else {
			enablePlayer (false);
		}

		if (menu.show) {
			if(!menu.isShowing) {
				menu.enableItem(true);
			}
		} else {
			if(menu.isShowing) {
			menu.enableItem(false);
			}
		}
		if (notification.show) {
			if(!notification.isShowing) {
				notification.enableItem(true);
			}
		} else {
			if(notification.isShowing) {
				notification.enableItem(false);
			}
		}

	}

	private void _checkPositionForChange() {
		var difference = Vector3.Distance(_lastPosition, camera.transform.position);

		if(difference > SIGNIFICANT_DISTANCE_CHANGE) {
//			Debug.Log("Player/Update, position = " + camera.transform.position + ", _lastPosition = " + _lastPosition + ", difference = " + difference);
			_dropBreadcrumb();
			_lastPosition = camera.transform.position;
		}
	}

	private void _dropBreadcrumb() {
		EventCenter.Instance.dropBreadcrumb(_lastPosition);
//		Breadcrumb _breadcrumbClone = (Breadcrumb) Instantiate(breadcrumb, _lastPosition, camera.transform.rotation);
	}

	void OnGUI () {
		MouseManager.Instance.drawCursor ();
		//Debug.Log("Player/OnGUI, showInventory = " + inventory.showInventory + ", showDetail = " + inventory.showDetail);
		if (inventory.showInventory) {
			inventory.drawSummary ();
			if(notification.show) {
				EventCenter.Instance.removeNote();
			}
		} else if (inventory.showDetail) {
			inventory.drawDetail ();
		} else if (notification.show) {
			notification.enableItem(true);
		} else if (inventory.houseKeepingNeeded) {
			inventory.houseKeeping ();
		}
	}
	
	public void onMouseSensitivityChange(float sensitivity) {
		MouseLook mouseLook = GetComponent<MouseLook>();
//		Debug.Log("Player/onMouseSensitivityChange, sensitivity = " + sensitivity);
		mouseLook.sensitivityX = sensitivity;
	}
	
	public void onEnablePlayer(bool enable) {
		enablePlayer(enable);
	}

	public void enablePlayer(bool enable) {
		// Debug.Log("Player/enablePlayer, disable = " + disable);
		headController.isEnabled = enable;
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
			menu.show = false;
		}
	}
}

