using UnityEngine;
using System.Collections;

public class InventoryManager {
	
	ArrayList inventory;
	
	bool showDetail = false;
	int inventoryLength;
	int inventoryWidth = 5;
	float iconWidthHeight = 100;
	int spacing = 20;
	Vector2 offset; 
	Texture emptySlot; 
	GUIStyle _style; 
	
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
		GUI.Box(new Rect(5, 5, Screen.width - 10, Screen.height - 10), "INVENTORY" /*, _style */);
		// Debug.Log("InventoryManager/DrawInventory, inventory.Count = " + inventory.Count);
	   	int j;
	    int k;
	    CollectableItem currentInventoryItem = null;
		CollectableItem detailInventoryItem = null;
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
					showDetail = true;
				}
			}
		}
		// Debug.Log("showDetail = " + showDetail + ", detailInventoryItem = " + detailInventoryItem);
		if(showDetail && detailInventoryItem != null) {
			Debug.Log("building detail of: " + detailInventoryItem.name);
			GUI.Box(new Rect(100, 100, Screen.width - 100, Screen.height - 100), detailInventoryItem.description);
			if(GUI.Button(new Rect(Screen.width - 200, 100, 100, 50), "close")) {
				detailInventoryItem = null;
				showDetail = false;
			}
		}

	}
	
	public void CloseInventoryWindow () {
    	//openInventoryWindow = false;
	}
 
}
