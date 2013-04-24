using UnityEngine;
using System.Collections;

public class Flashlight : MonoBehaviour {

	public bool collected = true;

	bool isOn = false;
	
	void Awake() {
		//bulb = this.transform.GetComp("flashlight_bulb");
		this.light.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(collected) {
			if(Input.GetKeyDown("f")) {
				this.light.enabled = !this.light.enabled;
				/*
				if(isOn) {
					// turn off
					Debug.Log("turning flashlight off");					
					this.enabled = false;
					isOn = false;
				} else {
					// turn on
					Debug.Log("turning flashlight on");
					this.enabled = true;
					isOn = true;
				}
				*/
			}
		}
	}
}
