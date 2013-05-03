using UnityEngine;
using System.Collections;

public class Flashlight : CollectableItem {

	Light bulb; 
	Transform flashlight_base;
	
	void Awake() {
		bulb = this.transform.Search("flashlight_bulb").light;
		bulb.enabled = false;
		flashlight_base = this.transform.Search("flashlight01e");
	}

	// Update is called once per frame
	void Update () {
		if(collected) {
			if(Input.GetKeyDown("f")) {
				bulb.enabled = !bulb.enabled;
				flashlight_base.renderer.enabled = bulb.enabled;
			}
		}
	}
	
	public override void OnMouseDown() {
		var difference = Vector3.Distance(Camera.mainCamera.gameObject.transform.position, this.transform.position);
		if(difference < interactDistance) {
			if(!collected) {
				collected = true;
				AttachTransforms();				
				//flashlight_base.renderer.enabled = bulb.enabled = true;
				AddToInventory();
			}
		}
	}
}
	