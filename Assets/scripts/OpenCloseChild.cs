using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class OpenCloseChild : InteractiveElement {
	public OpenCloseParent pops;
	public string openClipName;
	public string closeClipName;
	public bool isOpen;

	void Awake() {
		mouseManager = GameObject.Find ("player").GetComponent<MouseManager>();

	}

	public void OnMouseDown() {
		handleAnimation();
	}
	
	public void handleAnimation() {
		Debug.Log("OpenCloseChild/OnMouseDown, name = " + this.name);
		var difference = Vector3.Distance(Camera.mainCamera.gameObject.transform.position, this.transform.position);
		if(difference <= interactDistance) {
			// if(pops != null) {
				
				if(pops.currentOpen == this) {
					pops.CloseChild(this);
					isOpen = false;
				} else {
					pops.OpenChild(this);
					isOpen = true;
				}
			// }
		}
	}
}
