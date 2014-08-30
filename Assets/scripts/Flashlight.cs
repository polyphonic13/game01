using UnityEngine;
using System.Collections;

public class Flashlight : CollectableItem {

	private Light _bulb; 
	
	void Awake() {
		initCollectableItem();
		_bulb = this.transform.Search("flashlight_bulb").light;
		_bulb.enabled = false;
//		this.addToInventory ();
	}

	// Update is called once per frame
	void Update() {
		if(this.isCollected) {
			if(Input.GetKeyDown(KeyCode.F)) {
				EventCenter.Instance.equipItem(this.name);
			}
		}
	}
	
	public override void attach() {
		_bulb.enabled = false;
//		attachToRightHand();
		attachToLeftHand();
	}

	public override void equip() {
//		Debug.Log("Flashlight/equip");
		_bulb.enabled = true;
		use("left_hand");
	}

	public override void unequip() {
//		Debug.Log("Flashlight/store");
		_bulb.enabled = false;
		store();
	}
}
	