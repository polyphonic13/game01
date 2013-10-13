using UnityEngine;
using System.Collections;

public class InventoryManager {
	
	
//	public delegate void onItemCollected(string item);
//	public event onItemCollected itemCollected;
	
	private const float _detailImgWidthHeight = 500;

	private ArrayList _items;
	private Hashtable _itemsHash;
	
	private int _itemsLength;
	private int _itemsWidth = 5;
	private float _iconWidthHeight = 100;
	
	private int _spacing = 20;
	private Vector2 _offset; 
	private Texture _emptySlot; 
	private GUIStyle _style; 
	private InventoryItem _detailInventoryItem = null;
	
	public bool showInventory { get; set; }
	public bool showDetail { get; set; }
	
	public void init(GUIStyle style) {
		_style = style;
		_items = new ArrayList();	
		_itemsHash = new Hashtable();
		_offset = new Vector2(10, 10);
		//Debug.Log("_items/start, _items = " + _items);
	}
	
	public void addItem(InventoryItem item) {
		Debug.Log("_items manager/addItem, item = " + item + ", description = " + item.description);
		var player = GameObject.Find("player").GetComponent<Player>();
		player.notification.addNote(item.name + " added to inventory");
		//_items.Add (item);
		_itemsHash.Add(item.name, item);
		//this.itemCollected(item.name);
//		itemCollected("temp");
	}
	
	public bool hasItem(string name) {
		bool found = false;
		if(_itemsHash.Contains(name)) {
			return true;
		} else {
			return false;
		}
		
/*		
  		InventoryItem currentItem;
		for(int i = 0; i < _items.Count; i++) {
			currentItem = _items[i] as InventoryItem;
			// Debug.Log("currentItem.description = " + currentItem.description);
			if(currentItem.name == name) {
				found = true;
				break;
			}
		}
		return found;
*/		
	}
	
	public ArrayList getItems() {
		return _items;	
	}

	public void drawInventory() {
		this.drawBackground("inventory");
		// Debug.Log("InventoryManager/drawInventory, _items.Count = " + _items.Count);
	   	int j;
	    int k;
	    InventoryItem currentInventoryItem = null;
		Rect currentRect;

		for (int i = 0; i < _items.Count; i ++) {
	       j = i / _itemsWidth;
	       k = i % _itemsWidth;
	       currentInventoryItem = _items[i] as InventoryItem;
			Debug.Log("i = " + i + ", j = " + j + ", k = " + k + ", currentInventoryItem = " + currentInventoryItem.name);
	       currentRect = (new Rect (_offset.x + k * (_iconWidthHeight + _spacing), _offset.y + j * (_iconWidthHeight + _spacing), _iconWidthHeight, _iconWidthHeight));
	       //   ... if there is no item in the j-th row and the k-th column, draw a blank texture
			if (currentInventoryItem == null) {          
				GUI.DrawTexture (currentRect, _emptySlot);
			} else {
				// Debug.Log("about to draw texture for " + currentInventoryItem.iconTexture + ", currentRect = " + currentRect);
				GUI.DrawTexture(currentRect, currentInventoryItem.iconTexture);
				GUI.Box(new Rect(currentRect.x, currentRect.y, _iconWidthHeight, _iconWidthHeight), currentInventoryItem.name /*, _style */);
				if(GUI.Button(new Rect(currentRect.x, (currentRect.y + _iconWidthHeight + 5), _iconWidthHeight, 20), "examine")) {
//					Debug.Log("going to inspect item: " + i);
					_detailInventoryItem = _items[i] as InventoryItem;
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
			this.drawBackground("examine: " + _detailInventoryItem.name);
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
	
}
