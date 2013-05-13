using UnityEngine;
using System.Collections;

public class Lamp : MonoBehaviour {
	public int interactDistance = 3;

	Light bulb; 
	
	void Awake() {
		bulb = this.transform.Search("light_bulb").light;
		Debug.Log("bulb = " + bulb);
		bulb.enabled = false;
	}

	public void OnMouseDown() {
		// Debug.Log("Lamp/on mouse down");
		var difference = Vector3.Distance(Camera.mainCamera.gameObject.transform.position, this.transform.position);
		if(difference < interactDistance) {
			Debug.Log("Lamp/OnMouseDown, difference = " + difference);
			bulb.enabled = !bulb.enabled;	
		}
	}
}
