using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class OpenCloseChild : MonoBehaviour {
	public int interactDistance = 3;
	public OpenCloseParent pops;
	public string openClipName;
	public string closeClipName;
	public bool isOpen;
	
	public abstract void SetParent();
	public void OnMouseDown() {
		//Debug.Log("DresserDrawer/OnMouseDown, name = " + this.name);
		var difference = Vector3.Distance(Camera.mainCamera.gameObject.transform.position, this.transform.position);
		if(difference <= interactDistance) {
			if(isOpen) {
				pops.CloseChild(this);
				isOpen = false;
			} else {
				pops.OpenChild(this);
				isOpen = true;
			}
		}
	}
}
