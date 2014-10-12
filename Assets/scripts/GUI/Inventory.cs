using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Inventory : CanvasItem {

	public GridItem[] gridItems;

	public bool showDetail { get; set; }

	public bool isItemEquipped { get; set; }
	public string equippedItem { get; set; }

	public bool houseKeepingNeeded { get; set; }

	private const int ITEM_VIEWER_LAYER = 8;

	private Hashtable _itemsHash;
	
	private string _itemToDelete = ""; 

	private int availableGridElement = 0;

	private ItemViewer _itemViewer;
	private Camera _mainCamera;
	private Player _player;

	void Awake() {
		_itemViewer = GameObject.Find("itemViewer").GetComponent<ItemViewer>();
		_mainCamera = GameObject.Find("mainCamera").GetComponent<Camera>();

		_itemsHash = new Hashtable ();
		initCanvasItem ();
	}

	public void addItem(CollectableItem item) {
//		Debug.Log("Inventory/addItem, item = " + item.name + ", available idx = " + availableGridElement + ", gridItems length = " + gridItems.Length);
		if(availableGridElement < gridItems.Length) {
			EventCenter.Instance.addNote(item.itemName + " added to inventory");
			_itemsHash.Add(item.name, item);
			item.gridIdx = availableGridElement;
			var gridItem = gridItems[availableGridElement];
			gridItem.addItem(item);
			availableGridElement++;
		} else {
			EventCenter.Instance.addNote ("No more room in inventory for " + item.itemName);
		}
	}
	
	public bool hasItem(string name) {
		return _itemsHash.Contains(name);
	}
	
	public string getItemName(string key) {
		if(_itemsHash.Contains(key)) {
			var item = _itemsHash[key] as CollectableItem;
			return item.itemName;
		} else { 
			return "";
		}
	}
	
	public void selectItem(string name) {
		Debug.Log("Inventory/selectItem, name = " + name);
		if(hasItem(name)) {
			CollectableItem item = _itemsHash[name] as CollectableItem;
			Debug.Log("selected: " + item.itemName);
			if(item.itemViewerPrefab != null) {
				GameObject viewerItem = (GameObject) Instantiate(item.itemViewerPrefab, new Vector3(0,0,0), new Quaternion(0,0,0,0));
				viewerItem.layer = ITEM_VIEWER_LAYER;
				_itemViewer.addItem(viewerItem, name, item.itemName, item.description);
			}
		}
	}
	
	public void equipItem(string name) {
		if(hasItem(name)) {
			EventCenter.Instance.equipItem(name);
			this.equippedItem = name;
			this.isItemEquipped = true;
	        close();
		}
    }
    
	public void dropItem(string name) {
		if(hasItem(name)) {
			CollectableItem item = _itemsHash[name] as CollectableItem;
			item.drop();
//			_itemToDelete = equippedItem;
//			this.houseKeepingNeeded = true;
            _resetEquippedItem();
//			this.houseKeeping();	
			_itemsHash.Remove(name);
			_reorderGridItems(item.gridIdx);
			item.gridIdx = -1;
//            _itemToDelete = "";
        }
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

	public void houseKeeping() {
		Debug.Log("Inventory/houseKeeping, _itemToDelete = " + _itemToDelete);
		if(_itemToDelete != "") {
			CollectableItem item = _itemsHash[_itemToDelete] as CollectableItem;
			_reorderGridItems(item.gridIdx);
            _itemsHash.Remove(_itemToDelete);
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
		dropItem(itemName);
		close();
	}
	
	private void _reorderGridItems(int gridIdx) {
		Debug.Log("Inventory/_reorderGridItems, gridIdx = " + gridIdx);
		if(gridIdx > -1) {
			GridItem gridItem = gridItems[gridIdx];
			gridItem.removeItem();

			availableGridElement = 0;
			CollectableItem currentItem; 

			for(int i = 0; i < gridItems.Length; i++) {
				GridItem g = gridItems[i];
				Debug.Log("g["+i+"].isOccupied = " + g.isOccupied);
				if(g.isOccupied) {
                    g.removeItem();
                }
            }

			foreach(DictionaryEntry key in _itemsHash) {
				if(availableGridElement < gridItems.Length) {
					currentItem = key.Value as CollectableItem;
					GridItem g = gridItems[availableGridElement];
					currentItem.gridIdx = availableGridElement;
					g.addItem(currentItem);
					availableGridElement++;
				}
			}
		}
	}
}
