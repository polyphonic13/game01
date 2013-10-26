using UnityEngine;
using System.Collections;

public class OnOffLight : InteractiveElement {

	private Light _bulb; 

	void Awake() {
		initOnOffLight();
	}
	
	public void initOnOffLight() {
		init(MouseManager.Instance.INTERACT_CURSOR);
		_bulb = this.transform.Search("light_bulb").light;
		_bulb.enabled = false;
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
				this.toggle();
			}
		}
	}
	
	public virtual void toggle() {
		this.toggleBulb();
	}
	
	public void toggleBulb() {
		_bulb.enabled = !_bulb.enabled;
	}
	
	public bool getIsOn() {
		return _bulb.enabled;
	}
}
