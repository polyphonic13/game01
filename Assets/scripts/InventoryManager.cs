using UnityEngine;
using System.Collections;

public class InventoryManager {
	
	ArrayList inventoryArray;
	
	public void init() {
		inventoryArray = new ArrayList();	
		//Debug.Log("inventory/start, inventoryArray = " + inventoryArray);
	}
	
	public void AddItem(CollectableItem item) {
		Debug.Log("inventory manager/AddItem, item = " + item);
		inventoryArray.Add (item);	
	}
}
