using UnityEngine;
using System.Collections;

public class OnOffLight : InteractiveElement {

	Light bulb; 

	void Awake() {
		init(MouseManager.Instance.INTERACT_CURSOR);
		bulb = this.transform.Search("light_bulb").light;
		bulb.enabled = false;
//		Debug.Log("bulb = " + bulb);
	}

	public void OnMouseDown() {
		Debug.Log("OnOffLight[ " + this.name + " ]/OnMouseDown, isRoomActive = " + this.isRoomActive);
		if(this.isRoomActive) {
				var difference = Vector3.Distance(Camera.mainCamera.gameObject.transform.position, this.transform.position);
				if(difference < interactDistance) {
//					Debug.Log("Lamp/OnMouseDown, difference = " + difference + ", bulb.enabled = " + bulb.enabled);
					bulb.enabled = !bulb.enabled;	
				}
		}
	}
}
