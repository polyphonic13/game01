using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class OpenCloseChild : MonoBehaviour {
	public OpenCloseParent pops;
	public string openClipName;
	public string closeClipName;
	public bool isOpen;
	
	public abstract void SetParent();
	public void OnMouseDown() {
		//Debug.Log("DresserDrawer/OnMouseDown, name = " + this.name);
		if(isOpen) {
			pops.CloseChild(this);
			isOpen = false;
		} else {
			pops.OpenChild(this);
			isOpen = true;
		}
	}
}
