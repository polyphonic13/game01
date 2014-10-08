using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Inventory : CanvasItem {

	public GridItem[] gridItems;

	public bool showDetail { get; set; }

	public bool isItemEquipped { get; set; }
	public string equippedItem { get; set; }

	public bool houseKeepingNeeded { get; set; }

	private Hashtable _itemsHash;
	
	private string _itemToDelete = ""; 

	private int availableGridElement = 0;

	void Awake() {
		_itemsHash = new Hashtable ();
		initCanvasItem ();
	}

	public void addItem(CollectableItem item) {
		Debug.Log("Inventory/addItem, item = " + item.name + ", available idx = " + availableGridElement + ", gridItems length = " + gridItems.Length);
		if(availableGridElement < gridItems.Length) {
			EventCenter.Instance.addNote(item.itemName + " added to inventory");
			_itemsHash.Add(item.name, item);

			var gridItem = gridItems[availableGridElement];
			gridItem.addItem(item);
			availableGridElement++;
		} else {
			EventCenter.Instance.addNote ("No more room in inventory for " + item.itemName);
		}
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
//		var childTransforms = canvas.GetComponentsInChildren<Transform> ();
//		Debug.Log ("Inventory/_initGrid, childTransforms = " + childTransforms);
//		foreach(Transform childTransform in childTransforms) {
//			Debug.Log("child name = " + childTransform.gameObject.name);
//			initCollidableChild(childTransform.gameObject);
//		}
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
			CollectableItem item = _itemsHash[_itemToDelete] as CollectableItem;
			_itemsHash.Remove(_itemToDelete);
			_reorderGridItems(item.gridIdx);
			item.gridIdx = -1;
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
	
	private void _reorderGridItems(int gridIdx) {
		if(gridIdx > -1) {
			GridItem gridItem = gridItems[gridIdx];
			gridItem.removeItem();

			availableGridElement = 0;
			CollectableItem currentItem; 

			foreach(DictionaryEntry key in _itemsHash) {
				if(availableGridElement < gridItems.Length) {
					currentItem = key.Value as CollectableItem;
					GridItem g = gridItems[availableGridElement];
					if(g.isOccupied) {
						g.removeItem();
					}
					g.addItem(currentItem);
					availableGridElement++;
				}
			}
		}
	}
}
