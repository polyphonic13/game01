using UnityEngine;
using System.Collections;

public class InventoryManager {
	
	ArrayList inventory;
	
//	public delegate void onItemCollected(string item);
//	public event onItemCollected itemCollected;
	
	public bool showInventory = false;
	public bool showDetail = false;
	
	int inventoryLength;
	int inventoryWidth = 5;
	float iconWidthHeight = 100;
	
	const float detailImgWidthHeight = 500;
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
	
	public void addItem(CollectableItem item) {
		// Debug.Log("inventory manager/addItem, item = " + item + ", description = " + item.description);
		var player = GameObject.Find("player").GetComponent<Player>();
		player.notification.addNote(item.name + " added to inventory");
		inventory.Add (item);
		//this.itemCollected(item.name);
//		itemCollected("temp");
	}
	
	public bool hasItem(string name) {
		bool found = false;
		CollectableItem currentItem;
		for(int i = 0; i < inventory.Count; i++) {
			currentItem = inventory[i] as CollectableItem;
			// Debug.Log("currentItem.description = " + currentItem.description);
			if(currentItem.itemName == name) {
				found = true;
				break;
			}
		}
		return found;
	}
	
	public ArrayList getItems() {
		return inventory;	
	}

	public void drawInventory() {
		this.drawBackground("inventory");
		// Debug.Log("InventoryManager/drawInventory, inventory.Count = " + inventory.Count);
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
				// Debug.Log("about to draw texture for " + currentInventoryItem.iconTexture + ", currentRect = " + currentRect);
				GUI.DrawTexture(currentRect, currentInventoryItem.iconTexture);
				GUI.Box(new Rect(currentRect.x, currentRect.y, iconWidthHeight, iconWidthHeight), currentInventoryItem.name /*, _style */);
				if(GUI.Button(new Rect(currentRect.x, (currentRect.y + iconWidthHeight + 5), iconWidthHeight, 20), "examine")) {
					Debug.Log("going to inspect item: " + i);
					detailInventoryItem = inventory[i] as CollectableItem;
					this.showInventory = false;
					this.showDetail = true;
				}
			}
		}
	}
	
	public void drawDetail() {
		// Debug.Log("drawDetail = " + this.showDetail + ", detailInventoryItem = " + detailInventoryItem);
		if(detailInventoryItem != null) {
			var detailImgLeft = Screen.width/2 - detailImgWidthHeight/2;
			var detailImgTop = Screen.height/2 - detailImgWidthHeight/2;
			Rect detailRect = new Rect(detailImgLeft, detailImgTop, detailImgWidthHeight + 10, detailImgWidthHeight + 50);
			this.drawBackground("examine: " + detailInventoryItem.name);
			// Debug.Log("building detail of: " + detailInventoryItem.name);
			GUI.Box(detailRect, detailInventoryItem.description);
			GUI.DrawTexture(new Rect(detailImgLeft + 5, detailImgTop + 45, detailImgWidthHeight, detailImgWidthHeight), detailInventoryItem.iconTexture);
			if(GUI.Button(new Rect(detailImgLeft - 100, 75, 100, 20), "back")) {
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
	
	public void drawBackground(string title) {
		GUI.Box(new Rect(5, 5, Screen.width - 10, Screen.height - 10), title /*, _style */);
	}
	
	public void closeInventoryWindow() {
    	//openInventoryWindow = false;
	}
 
}
