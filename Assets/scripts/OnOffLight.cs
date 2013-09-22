using UnityEngine;
using System.Collections;

public class OnOffLight : InteractiveElement {

	Light bulb; 

	bool isOver = false;

	void Awake() {
				init (2);
		bulb = this.transform.Search("light_bulb").light;
		// Debug.Log("bulb = " + bulb);
		bulb.enabled = false;


	}

	public void OnMouseDown() {
		// Debug.Log("Lamp/on mouse down");
		var difference = Vector3.Distance(Camera.mainCamera.gameObject.transform.position, this.transform.position);
		if(difference < interactDistance) {
			Debug.Log("Lamp/OnMouseDown, difference = " + difference + ", bulb.enabled = " + bulb.enabled);
			bulb.enabled = !bulb.enabled;	
		}
	}
}
