using UnityEngine;
using System.Collections;

public class InventoryManager {
	
	ArrayList inventory;
	
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
		Debug.Log("inventory manager/AddItem, item = " + item + ", description = " + item.description);
		var player = GameObject.Find("player").GetComponent<Player>();
		player.notification.AddNote(item.description + " added to inventory");
		inventory.Add (item);	
	}
	
	public bool HasItem(string name) {
		bool found = false;
		CollectableItem currentItem;
		for(int i = 0; i < inventory.Count; i++) {
			currentItem = inventory[i] as CollectableItem;
			Debug.Log("currentItem.description = " + currentItem.description);
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
		Debug.Log("InventoryManager/DrawInventory, inventory.Count = " + inventory.Count);
	   	int j;
	    int k;
	    CollectableItem currentInventoryItem;                    //   Establish a variable to hold our data
	    Rect currentRect;

		for (int i = 0; i < inventory.Count; i ++) {                 //   Go through each row ...
	       j = i / inventoryWidth;                              //   ... divide by array by width to get rows...
	       k = i % inventoryWidth;                              //   ... find the remainder by width to get columns...
	       currentInventoryItem = inventory[i] as CollectableItem;                    //   ... set this point in the matrix as our current point ...
			Debug.Log("i = " + i + ", j = " + j + ", k = " + k + ", currentInventoryItem = " + currentInventoryItem.name);
	       currentRect = (new Rect (offset.x + k * (iconWidthHeight + spacing), offset.y + j * (iconWidthHeight + spacing), iconWidthHeight, iconWidthHeight));
	       //   ... if there is no item in the j-th row and the k-th column, draw a blank texture
			if (currentInventoryItem == null) {          
				GUI.DrawTexture (currentRect, emptySlot);
			} else {
				Debug.Log("about to draw texture for " + currentInventoryItem.icon + ", currentRect = " + currentRect);
				GUI.DrawTexture(currentRect, currentInventoryItem.icon);
				GUI.Box(new Rect(currentRect.x, currentRect.y, iconWidthHeight, iconWidthHeight), currentInventoryItem.description /*, _style */);
				//GUI.Button(new Rect(offset.x + iconWidthHeight, offset.y, iconWidthHeight, iconWidthHeight), currentInventoryItem.description);
			}
	 
	       //   If there is an item at this location and there is a button click...
//	       if (currentInventoryItem != null) 
//	       {
//	         if (Input.GetMouseButtonUp (0))                     //   ... if that click is mouse button 0: see the description
//	         {                                        
//	          GUIContent ("     " + currentInventoryItem.description);            // Get the description out
//	         } 
//	       }
	    }		

	}
	
	public void CloseInventoryWindow () {
    	//openInventoryWindow = false;
	}
 
}
