using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GridItem : MonoBehaviour {
	
	public bool isOccupied = false;
	public GameObject icon;
	public GameObject name;
	
	private Text nameTxt;
	private Image iconImg;
	
	void Start() {
		Debug.Log(this.gameObject.name + "/Start, nameTxt = " + nameTxt + ", iconImg = " + iconImg);
//		name.SetActive(false);
//		icon.SetActive(false);
	}
	
	public void addItem(CollectableItem item) {
//		name.SetActive(true);
//		icon.SetActive(true);
		nameTxt = name.GetComponent<Text>();
		iconImg = icon.GetComponent<Image>();

		Debug.Log(this.gameObject.name + "/addItem, item = " + item.itemName + ", nameTxt = " + nameTxt + ".text = " + nameTxt.text);
		nameTxt.text = item.itemName;
		
		if(item.iconSprite != null) {
			iconImg.sprite = item.iconSprite;
		}
	}
}
