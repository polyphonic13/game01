using UnityEngine;
using System.Collections;

public class Flashlight : CollectableItem {

	Light bulb; 
	
	void Awake() {
		bulb = this.transform.Search("flashlight_bulb").light;
		bulb.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if(collected) {
			if(Input.GetKeyDown("f")) {
				bulb.enabled = !bulb.enabled;
			}
		}
	}
	
	public void OnMouseDown() {
		Debug.Log("Flashlight/OnMouseDown");
		if(!collected) {
			collected = true;
			var hand = Camera.main.transform.Search("right_hand");
			Debug.Log("hand = " + hand + ", transform = " + hand.transform + ", position = " + hand.transform.position);
			if(hand) {
				this.transform.position = hand.transform.position;
				this.transform.rotation = hand.transform.rotation;
				this.transform.parent = hand.transform;
			}
		}
	}
}
	