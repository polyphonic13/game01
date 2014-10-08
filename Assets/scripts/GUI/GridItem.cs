using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GridItem : MonoBehaviour {
	
	public bool isOccupied = false;
	public GameObject icon;
	public GameObject name;
	
	private Text nameTxt;
	private Image iconImg;
	
	void Awake() {
		nameTxt = name.GetComponent<Text>();
		iconImg = icon.GetComponent<Image>();
		Debug.Log(this.gameObject.name + "/Start, nameTxt = " + nameTxt + ", iconImg = " + iconImg);
		name.gameObject.renderer.enabled = false;
		icon.gameObject.renderer.enabled = false;

	}
	
	public void addItem(CollectableItem item) {
		name.gameObject.renderer.enabled = true;
		icon.gameObject.renderer.enabled = true;

		Debug.Log(this.gameObject.name + "/addItem, item = " + item.itemName + ", nameTxt = " + nameTxt + ".text = " + nameTxt.text);
		nameTxt.text = item.itemName;
		
		if(item.iconSprite != null) {
			iconImg.sprite = item.iconSprite;
		}
	}
}
