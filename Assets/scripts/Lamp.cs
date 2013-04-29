using UnityEngine;
using System.Collections;

public class Lamp : MonoBehaviour {

	Light bulb; 
	
	void Awake() {
		bulb = this.transform.Search("light_bulb").light;
		bulb.enabled = false;
	}

	public void OnMouseDown() {
		// Debug.Log("Lamp/on mouse down");
		var difference = Vector3.Distance(Camera.mainCamera.gameObject.transform.position, this.transform.position);
		if(difference < 2) {
			Debug.Log("Flashlight/OnMouseDown, difference = " + difference);
			bulb.enabled = !bulb.enabled;	
		}
	}
}
