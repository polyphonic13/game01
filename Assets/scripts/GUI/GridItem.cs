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
	
	void Awake() {
		_nameTxt = name.GetComponent<Text>();
		_iconImg = icon.GetComponent<Image>();
		_group = this.gameObject.GetComponent<CanvasGroup>();
		_group.alpha = 0;

//		Debug.Log(this.gameObject.name + "/Start, _nameTxt = " + _nameTxt + ", _iconImg = " + _iconImg);

	}
	
	public void addItem(CollectableItem item) {
		Debug.Log(this.gameObject.name + "/addItem, item = " + item.itemName);
		this.isOccupied = true;
		_group.alpha = 1;
		_nameTxt.text = item.itemName;
		
		if(item.iconSprite != null) {
//			Debug.Log("  adding sprite: " + item.iconSprite);
			_iconImg.sprite = item.iconSprite;
		}
	}

	public void removeItem() {
		this.isOccupied = false;
//		Debug.Log(this.gameObject.name + "/removeItem");
		_group.alpha = 0;
		_nameTxt.text = "";
		_iconImg.sprite = null;
	}
}
