using UnityEngine;
using System.Collections;

public class InventoryManager {
	
	ArrayList inventory;
	
	int inventoryLength;
	int inventoryWidth;
	float iconWidthHeight = 100;
	int spacing = 10;
	Vector2 offset; 
	Texture emptySlot; 
	
	public void init() {
		inventory = new ArrayList();	
		//Debug.Log("inventory/start, inventory = " + inventory);
	}
	
	public void AddItem(CollectableItem item) {
		Debug.Log("inventory manager/AddItem, item = " + item + ", description = " + item.description);
		inventory.Add (item);	
	}
	
	public ArrayList GetItems() {
		return inventory;	
	}

	public void DrawInventory() {
		Debug.Log("InventoryManager/DrawInventory, inventory.Count = " + inventory.Count);
	   	int j;
	    int k;
	    CollectableItem currentInventoryItem;                    //   Establish a variable to hold our data
	    Rect currentRect;
	    
		for (int i = 0; i < inventory.Count; i ++) {                 //   Go through each row ...
	       j = i / inventoryWidth;                              //   ... divide by array by width to get rows...
	       k = i % inventoryWidth;                              //   ... find the remainder by width to get columns...
	       currentInventoryItem = inventory[i] as CollectableItem;                    //   ... set this point in the matrix as our current point ...
	       currentRect = (new Rect (offset.x + k * (iconWidthHeight + spacing), offset.y + j * (iconWidthHeight + spacing), iconWidthHeight, iconWidthHeight));
	       if (currentInventoryItem == null)           //   ... if there is no item in the j-th row and the k-th column, draw a blank texture
	       {                     
	         GUI.DrawTexture (currentRect, emptySlot);
	       } 
	       else 
	       {
	         GUI.DrawTexture (currentRect, currentInventoryItem.icon);
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
