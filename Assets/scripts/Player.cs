using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public string startingRoom = "";

	public Breadcrumb breadcrumb;

//	public InventoryManager inventory;
	public Inventory inventory;
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
//		menu = new Menu();
//		menu.init ();
		menu.show = true;
//		inventory.show = false;
//		notification.show = false;
//		inventory = new InventoryManager();
//		inventory.init(basicStyle);
//		inventory = new Inventory ();
//		inventory.init ();
//		notification = new Notification();
//		notification.init ();
		EventCenter eventCenter = EventCenter.Instance;
		eventCenter.onEnablePlayer += this.onEnablePlayer;
		eventCenter.onMouseSensitivityChange += this.onMouseSensitivityChange;
		headController = GetComponent<PlayerMeshController> ();
	}
	
	void Update() {
		_checkPositionForChange();
		if(Input.GetKeyDown(KeyCode.Q)) {
			inventory.show = !inventory.show;
			inventory.showDetail = false;
		} else if(Input.GetKeyDown(KeyCode.X) && inventory.isItemEquipped) {
			inventory.dropItem();
		} else if(Input.GetKeyDown(KeyCode.M)) {
			menu.show = !menu.show;
		} else if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) {
			inventory.showDetail = false;
			inventory.show = false;
			menu.show = false;
			if(notification.show) {
				notification.destroy();
			}
		}
		if (!inventory.showDetail && !inventory.show && !menu.show && !notification.show) {
			enablePlayer (true);
		} else {
			enablePlayer (false);
		}

		if (menu.show) {
			if(!menu.isShowing) {
				openMenu();
				if(inventory.isShowing) {
					closeInventory();
				}
				if(notification.isShowing) {
					closeNotification();
				}
			}
		} else {
			if(menu.isShowing) {
				Debug.Log("Player/Update, menu.show = " + menu.show + ", isShowing = " + menu.isShowing);
				closeMenu();
			}
		}
		if (notification.show) {
			if(!notification.isShowing) {
				notification.showHide(true);
			}
		} else {
			if(notification.isShowing) {
				notification.showHide(false);
			}
		}
		if (inventory.show) {
			if (!inventory.isShowing) {
				openInventory ();
				if (notification.isShowing) {
					closeNotification ();
				}
				if (menu.isShowing) {
					closeMenu ();
				}
			}
		} else {
			if (inventory.isShowing) {
				closeInventory ();
			}
		}

	}

	public void openMenu() {
		Debug.Log ("Player/openMenu");
		menu.showHide(true);
	}

	public void closeMenu() {
		menu.show = false;
		menu.showHide(false);
	}

	public void openInventory() {
		Debug.Log ("Player/openInventory");
		inventory.showHide (true);
	}

	public void closeInventory() {
		inventory.show = false;
		inventory.showHide (false);
	}

	public void closeNotification() {
		notification.show = false;
		notification.destroy ();
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
		//Debug.Log("Player/OnGUI, showInventory = " + inventory.show + ", showDetail = " + inventory.showDetail);
//		if (inventory.show) {
//			inventory.drawSummary ();
//			openInventory();
//			if(notification.show) {
//				closeNotification();
//			}
//		} else if (inventory.showDetail) {
//			inventory.drawDetail ();
//		} else if (notification.show) {
//			notification.showHide(true);
//		} else if (inventory.houseKeepingNeeded) {
//			inventory.houseKeeping ();
//		}
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
			inventory.show = false;
			menu.show = false;
		}
	}
}

