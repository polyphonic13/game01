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
				if (this.isInUse) {
					store();
				} else {
					equip ();
				}
			}
		}
	}
	
	public override void attach () {
		_bulb.enabled = false;
		attachToRightHand();
	}

	public override void equip () {
		_bulb.enabled = true;
		use();
	}

	public override void store() {
		_bulb.enabled = false;
		putAway();
	}
}
	