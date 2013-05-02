using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	bool inventoryOpen = false;
	InventoryManager inventory;
	
	// Use this for initialization
	void Start () {
		inventory = new InventoryManager();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("q")) {
			if(inventoryOpen) {
				Debug.Log("close inventory");
				this.OpenInventory();
			} else {
				Debug.Log("open inventory");
				this.CloseInventory();
			}
			inventoryOpen = !inventoryOpen;
		}
	}
	
	void OpenInventory() {
		inventory.ShowItems();
	}
	
	void CloseInventory() {
		inventory.HideItems();
	}

}
