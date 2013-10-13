using UnityEngine;
using System.Collections;

public class InventoryManager {
	
	
//	public delegate void onItemCollected(string item);
//	public event onItemCollected itemCollected;
	
	private const float _detailImgWidthHeight = 500;

	private ArrayList _inventory;

	private int _inventoryLength;
	private int _inventoryWidth = 5;
	private float _iconWidthHeight = 100;
	
	private int _spacing = 20;
	private Vector2 _offset; 
	private Texture _emptySlot; 
	private GUIStyle _style; 
	private CollectableItem _detailInventoryItem = null;
	
	public bool showInventory { get; set; }
	public bool showDetail { get; set; }
	
	public void init(GUIStyle style) {
		_style = style;
		_inventory = new ArrayList();	
		_offset = new Vector2(10, 10);
		//Debug.Log("_inventory/start, _inventory = " + _inventory);
	}
	
	public void addItem(CollectableItem item) {
		// Debug.Log("_inventory manager/addItem, item = " + item + ", description = " + item.description);
		var player = GameObject.Find("player").GetComponent<Player>();
		player.notification.addNote(item.itemName + " added to inventory");
		_inventory.Add (item);
		//this.itemCollected(item.name);
//		itemCollected("temp");
	}
	
	public bool hasItem(string name) {
		bool found = false;
		CollectableItem currentItem;
		for(int i = 0; i < _inventory.Count; i++) {
			currentItem = _inventory[i] as CollectableItem;
			// Debug.Log("currentItem.description = " + currentItem.description);
			if(currentItem.itemName == name) {
				found = true;
				break;
			}
		}
		return found;
	}
	
	public ArrayList getItems() {
		return _inventory;	
	}

	public void drawInventory() {
		this.drawBackground("inventory");
		// Debug.Log("InventoryManager/drawInventory, _inventory.Count = " + _inventory.Count);
	   	int j;
	    int k;
	    CollectableItem currentInventoryItem = null;
	    string itemName;
		Rect currentRect;

		for (int i = 0; i < _inventory.Count; i ++) {
	       j = i / _inventoryWidth;
	       k = i % _inventoryWidth;
	       currentInventoryItem = _inventory[i] as CollectableItem;
			// Debug.Log("i = " + i + ", j = " + j + ", k = " + k + ", currentInventoryItem = " + currentInventoryItem.name);
	       currentRect = (new Rect (_offset.x + k * (_iconWidthHeight + _spacing), _offset.y + j * (_iconWidthHeight + _spacing), _iconWidthHeight, _iconWidthHeight));
	       //   ... if there is no item in the j-th row and the k-th column, draw a blank texture
			if (currentInventoryItem == null) {          
				GUI.DrawTexture (currentRect, _emptySlot);
			} else {
				// Debug.Log("about to draw texture for " + currentInventoryItem.iconTexture + ", currentRect = " + currentRect);
				GUI.DrawTexture(currentRect, currentInventoryItem.iconTexture);
				GUI.Box(new Rect(currentRect.x, currentRect.y, _iconWidthHeight, _iconWidthHeight), currentInventoryItem.itemName /*, _style */);
				if(GUI.Button(new Rect(currentRect.x, (currentRect.y + _iconWidthHeight + 5), _iconWidthHeight, 20), "examine")) {
//					Debug.Log("going to inspect item: " + i);
					_detailInventoryItem = _inventory[i] as CollectableItem;
					this.showInventory = false;
					this.showDetail = true;
				}
			}
		}
	}
	
	public void drawDetail() {
		// Debug.Log("drawDetail = " + this.showDetail + ", _detailInventoryItem = " + _detailInventoryItem);
		if(_detailInventoryItem != null) {
			var detailImgLeft = Screen.width/2 - _detailImgWidthHeight/2;
			var detailImgTop = Screen.height/2 - _detailImgWidthHeight/2;
			Rect detailRect = new Rect(detailImgLeft, detailImgTop, _detailImgWidthHeight + 10, _detailImgWidthHeight + 50);
			this.drawBackground("examine: " + _detailInventoryItem.itemName);
			// Debug.Log("building detail of: " + _detailInventoryItem.name);
			GUI.Box(detailRect, _detailInventoryItem.description);
			GUI.DrawTexture(new Rect(detailImgLeft + 5, detailImgTop + 45, _detailImgWidthHeight, _detailImgWidthHeight), _detailInventoryItem.iconTexture);
			if(GUI.Button(new Rect(detailImgLeft - 100, 75, 100, 20), "back")) {
				_detailInventoryItem = null;
				this.showDetail = false;
				this.showInventory = true;
			}
		} else {
			Debug.Log("ERROR: _detailInventoryItem is null");
			this.showDetail = false;
			this.showInventory = false;
		}
	}
	
	public void drawBackground(string title) {
		GUI.Box(new Rect(5, 5, Screen.width - 10, Screen.height - 10), title /*, _style */);
	}
	
	public void closeInventoryWindow() {
    	//openInventoryWindow = false;
	}
 
}
