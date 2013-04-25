using UnityEngine;
using System.Collections;

public class Flashlight : MonoBehaviour {

	public bool collected = false;
	Light bulb; 
	
	void Awake() {
		//bulb = this.transform.GetComp("flashlight_bulb");
		// this.light.enabled = false;
		bulb = this.transform.Search("flashlight_bulb").light;
		bulb.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if(collected) {
			if(Input.GetKeyDown("f")) {
				//this.light.enabled = !this.light.enabled;
				bulb.enabled = !bulb.enabled;
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
	
	public void OnMouseDown() {
		if(!collected) {
			collected = true;
			
		}
	}
}
