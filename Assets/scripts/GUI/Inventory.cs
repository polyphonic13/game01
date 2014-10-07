using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Inventory : CanvasItem {

	public const string CANVAS_NAME = "inventoryUI";

	public bool showDetail { get; set; }

	public bool isItemEquipped { get; set; }
	public string equippedItem { get; set; }

	public bool houseKeepingNeeded { get; set; }

	private Hashtable _itemsHash;
	
	private string _itemToDelete = ""; 
	
	// Use this for initialization
	public void init() {
		showDetail = false;
		isItemEquipped = false;
		houseKeepingNeeded = false;
		base.init (CANVAS_NAME);
//		_initGrid ();
	}

	public void addItem(CollectableItem item) {
		//		Debug.Log("_items manager/addItem, item = " + item.name + ", description = " + item.description);
		EventCenter.Instance.addNote(item.itemName + " added to inventory");
		_itemsHash.Add(item.name, item);
	}
	
	public bool hasItem(string name) {
		bool found = false;
		if(_itemsHash.Contains(name)) {
			return true;
		} else {
			return false;
		}
	}
	
	public string getItemName(string key) {
		if(_itemsHash.Contains(key)) {
			var item = _itemsHash[key] as CollectableItem;
			return item.itemName;
		} else { 
			return "";
		}
	}
	
	public void dropItem() {
		CollectableItem item = _itemsHash[equippedItem] as CollectableItem;
		item.drop();
		_itemToDelete = equippedItem;
		this.houseKeepingNeeded = true;
		_resetEquippedItem();
	}

	public void close() {
		this.show = false;
		this.showDetail = false;
		EventCenter.Instance.enablePlayer(true);
	}

	private void _initGrid() {
		var childTransforms = canvas.GetComponentsInChildren<Transform> ();
		Debug.Log ("Inventory/_initGrid, childTransforms = " + childTransforms);
		foreach(Transform childTransform in childTransforms) {
			Debug.Log("child name = " + childTransform.gameObject.name);
//			initCollidableChild(childTransform.gameObject);
		}
	}

	private void _equipAndClose(string itemName) {
		EventCenter.Instance.equipItem(itemName);
		this.equippedItem = itemName;
		this.isItemEquipped = true;
		close();
	}
	
	public void houseKeeping() {
		Debug.Log("Inventory/houseKeeping, _itemToDelete = " + _itemToDelete);
		if(_itemToDelete != "") {
			_itemsHash.Remove(_itemToDelete);
			_itemToDelete = "";
		}
		this.houseKeepingNeeded = false;
	}
	
	private void _resetEquippedItem() {
		this.equippedItem = "";
		this.isItemEquipped = false;
	}
	
	private void _dropAndClose(string itemName) {
		dropItem();
		close();
	}
	

}
