using UnityEngine;
using System.Collections;

public class Flashlight : MonoBehaviour {

	public bool collected = true;

	bool isOn = false;
	
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
