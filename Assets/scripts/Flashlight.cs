using UnityEngine;
using System.Collections;

public class Flashlight : CollectableItem {

	private Light _bulb; 
	
	void Awake() {
		initCollectableItem();
		_bulb = this.transform.Search("flashlight_bulb").light;
		_bulb.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if (this.isCollected) {
			if (Input.GetKeyDown (KeyCode.F)) {
				EventCenter.Instance.equipItem(this.name);
//				if (this.isInUse) {
//					store();
//				} else {
//					equip ();
//				}
			}
		}
	}
	
	public override void attach () {
		_bulb.enabled = false;
		attachToRightHand();
	}

	public override void equip () {
		Debug.Log("Flashlight/equip");
		_bulb.enabled = true;
		use();
	}

	public override void store() {
		Debug.Log("Flashlight/store");
		_bulb.enabled = false;
		putAway();
	}
}
	