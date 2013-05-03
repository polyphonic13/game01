using UnityEngine;
using System.Collections;

public class InventoryManager {
	
	ArrayList inventory;
	
	int inventoryLength;
	int inventoryWidth;
	float itemIconWidthHeight = 100;
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
	   	int j;
	    int k;
	    CollectableItem currentInventoryItem;                    //   Establish a variable to hold our data
	    Rect currentRect;
	    
		for (int i = 0; i < inventory.length; i ++) {                 //   Go through each row ...
	       j = i / inventoryWidth;                              //   ... divide by array by width to get rows...
	       k = i % inventoryWidth;                              //   ... find the remainder by width to get columns...
	       currentInventoryItem = inventory[i];                    //   ... set this point in the matrix as our current point ...
	       currentRect = (new Rect (offSet.x + k * (iconWidthHeight + spacing), offSet.y + j * (iconWidthHeight + spacing), iconWidthHeight, iconWidthHeight));
	       if (currentInventoryItem == null)           //   ... if there is no item in the j-th row and the k-th column, draw a blank texture
	       {                     
	         GUI.DrawTexture (currentRect, emptySlot);
	       } 
	       else 
	       {
	         GUI.DrawTexture (currentRect, currentInventoryItem.itemIcon);
	       }
	 
	       //   If there is an item at this location and there is a button click...
	       if (currentInventoryItem != null && GUI.Button (currentRect, "", GUIStyle ("label"))) 
	       {
	         if (Input.GetMouseButtonUp (0))                     //   ... if that click is mouse button 0: see the description
	         {                                        
	          GUIContent ("     " + currentInventoryItem.itemDescription);            // Get the description out
	         } 
	 
	 
	       }
	    }		
	}
	
	public void CloseInventoryWindow () {
    	//openInventoryWindow = false;
	}
 
}
