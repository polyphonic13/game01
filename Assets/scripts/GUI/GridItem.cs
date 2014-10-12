using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GridItem : MonoBehaviour {
	
	public bool isOccupied = false;
	public GameObject icon;
	public GameObject name;

	private CanvasGroup _group;
	private Text _nameTxt;
	private Image _iconImg;

	private Inventory _inventory;
	private string _itemName;

	void Awake() {
		_nameTxt = name.GetComponent<Text>();
		_iconImg = icon.GetComponent<Image>();
		_group = this.gameObject.GetComponent<CanvasGroup>();
		_group.alpha = 0;
		_inventory = GameObject.Find("inventoryUI").GetComponent<Inventory>();
//		Debug.Log(this.gameObject.name + "/Start, _nameTxt = " + _nameTxt + ", _iconImg = " + _iconImg);

	}
	
	public void addItem(CollectableItem item) {
		Debug.Log(this.gameObject.name + "/addItem, item = " + item.itemName);
		this.isOccupied = true;
		_itemName = item.name;
		_group.alpha = 1;
		_nameTxt.text = item.itemName;
		
		if(item.iconSprite != null) {
//			Debug.Log("  adding sprite: " + item.iconSprite);
			_iconImg.sprite = item.iconSprite;
		}
	}

	public void selectItem() {
		Debug.Log(this.gameObject.name + "/selectItem, item = " + _itemName);
		_inventory.selectItem(_itemName);
	} 

	public void test() {
		Debug.Log(this.gameObject.name + "/test");
	}

	public void removeItem() {
		Debug.Log(this.gameObject.name + "/removeItem");
        this.isOccupied = false;
		_itemName = "";
		_group.alpha = 0;
		_nameTxt.text = "";
		_iconImg.sprite = null;
	}
}
