using UnityEngine;
using System.Collections;

public class OnOffLight : InteractiveElement {

	private Light _bulb; 

	void Awake() {
		init(MouseManager.Instance.INTERACT_CURSOR);
		_bulb = this.transform.Search("light_bulb").light;
		_bulb.enabled = false;
		Debug.Log("OnOffLight[ " + this.name + " ]/Awake, _bulb = " + _bulb);
	}

	public override void OnMouseOver() {
		Debug.Log("OnOffLight[ " + this.name + " ]/OnMouseOver, isRoomActive = " + this.isRoomActive + ", isEnabled = " + this.isEnabled);
		if(this.isRoomActive && this.isEnabled) {
			mouseOver();
		}
	}

	public void OnMouseDown() {
		Debug.Log("OnOffLight[ " + this.name + " ]/OnMouseDown, isRoomActive = " + this.isRoomActive);
		if(this.isRoomActive) {
			var difference = Vector3.Distance(Camera.mainCamera.gameObject.transform.position, this.transform.position);
			Debug.Log("  difference = " + difference + ", _bulb.enabled = " + _bulb.enabled);
			if(difference < interactDistance) {
				_bulb.enabled = !_bulb.enabled;	
			}
		}
	}
	
	public void toggle() {
		_bulb.enabled = !_bulb.enabled;
	}
}
