using UnityEngine;
using System.Collections;

public class InventoryManager {
	
	ArrayList inventory;
	
	public bool showInventory = false;
	public bool showDetail = false;
	
	int inventoryLength;
	int inventoryWidth = 5;
	float iconWidthHeight = 100;
	int spacing = 20;
	Vector2 offset; 
	Texture emptySlot; 
	GUIStyle _style; 
	CollectableItem detailInventoryItem = null;
	
	public void init(GUIStyle style) {
		_style = style;
		inventory = new ArrayList();	
		offset = new Vector2(10, 10);
		//Debug.Log("inventory/start, inventory = " + inventory);
	}
	
	public void AddItem(CollectableItem item) {
		// Debug.Log("inventory manager/AddItem, item = " + item + ", description = " + item.description);
		var player = GameObject.Find("player").GetComponent<Player>();
		player.notification.AddNote(item.name + " added to inventory");
		inventory.Add (item);	
	}
	
	public bool HasItem(string name) {
		bool found = false;
		CollectableItem currentItem;
		for(int i = 0; i < inventory.Count; i++) {
			currentItem = inventory[i] as CollectableItem;
			// Debug.Log("currentItem.description = " + currentItem.description);
			if(currentItem.description == name) {
				found = true;
				break;
			}
		}
		return found;
	}
	
	public ArrayList GetItems() {
		return inventory;	
	}

	public void DrawInventory() {
		this.DrawBackground("INVENTORY");
		// Debug.Log("InventoryManager/DrawInventory, inventory.Count = " + inventory.Count);
	   	int j;
	    int k;
	    CollectableItem currentInventoryItem = null;
	    string itemName;
		Rect currentRect;

		for (int i = 0; i < inventory.Count; i ++) {
	       j = i / inventoryWidth;
	       k = i % inventoryWidth;
	       currentInventoryItem = inventory[i] as CollectableItem;
			// Debug.Log("i = " + i + ", j = " + j + ", k = " + k + ", currentInventoryItem = " + currentInventoryItem.name);
	       currentRect = (new Rect (offset.x + k * (iconWidthHeight + spacing), offset.y + j * (iconWidthHeight + spacing), iconWidthHeight, iconWidthHeight));
	       //   ... if there is no item in the j-th row and the k-th column, draw a blank texture
			if (currentInventoryItem == null) {          
				GUI.DrawTexture (currentRect, emptySlot);
			} else {
				// Debug.Log("about to draw texture for " + currentInventoryItem.icon + ", currentRect = " + currentRect);
				GUI.DrawTexture(currentRect, currentInventoryItem.icon);
				GUI.Box(new Rect(currentRect.x, currentRect.y, iconWidthHeight, iconWidthHeight), currentInventoryItem.name /*, _style */);
				if(GUI.Button(new Rect(currentRect.x, (currentRect.y + iconWidthHeight), iconWidthHeight, 20), "examine")) {
					Debug.Log("going to inspect item: " + i);
					detailInventoryItem = inventory[i] as CollectableItem;
					this.showInventory = false;
					this.showDetail = true;
				}
			}
		}
	}
	
	public void DrawDetail() {
		// Debug.Log("DrawDetail = " + this.showDetail + ", detailInventoryItem = " + detailInventoryItem);
		if(detailInventoryItem != null) {
			this.DrawBackground(detailInventoryItem.name + " DETAIL");
			Debug.Log("building detail of: " + detailInventoryItem.name);
			GUI.Box(new Rect(200, 200, Screen.width - 400, Screen.height - 400), detailInventoryItem.description);
			if(GUI.Button(new Rect(Screen.width - 200, 100, 100, 50), "close")) {
				detailInventoryItem = null;
				this.showDetail = false;
				this.showInventory = true;
			}
		} else {
			Debug.Log("ERROR: detailInventoryItem is null");
			this.showDetail = false;
			this.showInventory = false;
		}
	}
	
	public void DrawBackground(string title) {
		GUI.Box(new Rect(5, 5, Screen.width - 10, Screen.height - 10), title /*, _style */);
	}
	
	public void CloseInventoryWindow () {
    	//openInventoryWindow = false;
	}
 
}
