using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArmatureTrigger : MonoBehaviour {
	public int interactDistance = 3;
	public ArmatureParent pops;
	public string openClipName;
	public string closeClipName;
	public bool isOpen = false;
	
	public void OnMouseDown() {
		handleAnimation();
	}
	
	public void handleAnimation() {
		Debug.Log("ArmatureTrigger/OnMouseDown, name = " + this.name);
		var difference = Vector3.Distance(Camera.mainCamera.gameObject.transform.position, this.transform.position);
		if(difference <= interactDistance) {
			if(isOpen) {
				pops.PlayAnimation(closeClipName);
			} else {
				pops.PlayAnimation(openClipName);
			}
			isOpen = !isOpen;
			// if(pops != null) {
				/*
				if(pops.currentOpen == this) {
					pops.CloseChild(this);
					isOpen = false;
				} else {
					pops.OpenChild(this);
					isOpen = true;
				}
				*/
			// }
		}
	}
}
