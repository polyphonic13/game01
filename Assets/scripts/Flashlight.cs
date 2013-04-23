using UnityEngine;
using System.Collections;

public class Flashlight : MonoBehaviour {

	public bool collected = true;

	bool isOn = false;
	Light bulb;
	
	void Awake() {
		bulb = this.transform.GetComponentInChildren("flashlight_bulb");
		Debug.Log("bulb = " + bulb);
	}
	
	// Update is called once per frame
	void Update () {
		if(collected) {
			if(Input.GetKeyDown("f")) {
				if(isOn) {
					// turn off
					Debug.Log("turning flashlight off");					
				} else {
					// turn on
					Debug.Log("turning flashlight on");
				}
				isOn = !isOn;
			}
		}
	}
}
