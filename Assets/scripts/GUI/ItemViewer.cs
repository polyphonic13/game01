using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemViewer : MonoBehaviour {

	public Camera viewer;
	public Transform tgt;
	public float rotationSpeed = 150.0f;
	public float zoomSpeed = 3.0f; 
	public float zoomMax = 6.0f;
	public float zoomMin = 1.0f;

	public bool hasItem { get; set; }

	private Quaternion _startRot;
	private Vector3 _startPos;

	private Player _player;
	private Inventory _inventory;
    private GameObject _target;
	private Camera _viewerCamera; 
	private CanvasGroup _canvasGroup;
	private GraphicRaycaster _raycaster;

	private string _itemKey;
	private Text _itemName;
	private Text _itemDescription; 

	void Awake () {
		_player = GameObject.Find("player").GetComponent<Player>();
		_inventory = GameObject.Find ("inventoryUI").GetComponent<Inventory>();
		_viewerCamera = GameObject.Find("viewerCamera").GetComponent<Camera>();
		var _viewerUI = GameObject.Find ("viewerUI"); 
		_canvasGroup = _viewerUI.GetComponent<CanvasGroup>();
		_raycaster = _viewerUI.GetComponent<GraphicRaycaster>();

		_itemName = GameObject.Find ("inventoryItemName").GetComponent<Text>();
		_itemDescription = GameObject.Find ("inventoryItemDescription").GetComponent<Text>();

		_viewerCamera.enabled = false;
		_canvasGroup.alpha = 0;
		_raycaster.enabled = false;
		_startRot = viewer.transform.rotation;
		_startPos = viewer.transform.position;
	}
	
	void Update () {
		if(tgt != null) {
			if(Input.GetKeyDown(KeyCode.Q)) {
				close();
			} else if(Input.GetKeyDown(KeyCode.R)) {
				// reset rotation and position
				reset ();
			} else {
				int orbitX = 0;
				int orbitY = 0;
				int move = 0;
				var distance = Vector3.Distance(viewer.transform.position, tgt.transform.position);
				
				// ROTATION
				// up/down orbit (y axis)
				if(Input.GetKey(KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
					orbitY = 1;
				} else if(Input.GetKey(KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
					orbitY = -1;
				}
				// left/right orbit (x axis)
				if(Input.GetKey(KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {
					orbitX = 1;
				} else if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
					orbitX = -1;
				}
				
				_orbit(new Vector3(orbitX, orbitY, 0));
                if(Input.GetKey (KeyCode.Z) || Input.GetKey(KeyCode.Plus)) {
                    if(distance > zoomMin) {
                        move = 1;
                    }
                } else if(Input.GetKey (KeyCode.X) || Input.GetKey (KeyCode.Minus)) {
                    if(distance < zoomMax) {
                        move = -1;
                    }
                }
                
                if(move != 0) {
                    _move (move);
                }
            }
        }
	}
	
	public void addItem(GameObject target, string key = "", string itemName = "", string description = "") {
		_itemKey = key;
		_itemName.text = itemName;
		_itemDescription.text = description;

		_player.viewingInventoryItem(true);
        _viewerCamera.enabled = true;
		_raycaster.enabled = true;
		_canvasGroup.alpha = 1;
		if(hasItem) {
			removeItem();
		}
		_target = target;
		tgt = target.transform;
		hasItem = true;
	}

	public void removeItem() {
		if(hasItem) {
			Destroy(_target);
			tgt = null;
			reset ();
			hasItem = false;
			_itemKey = "";
			_itemName.text = "";
			_itemDescription.text = "";
		}
	}

	public void reset() {
		viewer.transform.rotation = _startRot;
		viewer.transform.position = _startPos;
	}

	public void equipInventoryItem() {
		_inventory.equipItem(_itemKey);
		close ();
    }
	
	public void dropInventoryItem() {
		_inventory.dropItem(_itemKey);
		close ();
	}

	public void close() {
		removeItem();
		_viewerCamera.enabled = false;
		_raycaster.enabled = false;
		_canvasGroup.alpha = 0;
		_player.viewingInventoryItem(false);
    }

	private void _orbit(Vector3 axis) {
		viewer.transform.RotateAround (tgt.position, axis, rotationSpeed * Time.deltaTime);
	}

	private void _move(int forwardFactor) {
		float speed = zoomSpeed * forwardFactor;
		viewer.transform.position += viewer.transform.forward * speed * Time.deltaTime;
	}
}
