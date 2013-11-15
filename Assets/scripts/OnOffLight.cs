using UnityEngine;
using System.Collections;

public class OnOffLight : InteractiveElement {

	public Light bulb; 
	
	void Awake() {
		initOnOffLight();
		init(MouseManager.Instance.INTERACT_CURSOR);
	}
	
	public void initOnOffLight() {
		bulb = this.transform.Search("light_bulb").light;
		bulb.enabled = false;
	}

	public override void OnMouseOver() {
//		Debug.Log("OnOffLight[ " + this.name + " ]/OnMouseOver, isRoomActive = " + this.isRoomActive + ", isEnabled = " + this.isEnabled);
		if(this.isRoomActive && this.isEnabled) {
			mouseOver();
		}
	}

	public void OnMouseDown() {
		Debug.Log("OnOffLight[ " + this.name + " ]/OnMouseDown, isRoomActive = " + this.isRoomActive);
		if(this.isRoomActive) {
			var difference = Vector3.Distance(Camera.mainCamera.gameObject.transform.position, this.transform.position);
//			Debug.Log("  difference = " + difference + ", bulb.enabled = " + bulb.enabled);
			if(difference < interactDistance) {
				this.toggle();
			}
		}
	}
	
	public virtual void toggle() {
		this.toggleBulb(bulb);
	}
	
	public void toggleBulb(Light light) {
		light.enabled = !light.enabled;
	}
	
	public bool getIsOn() {
		return bulb.enabled;
	}
}
