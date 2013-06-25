using UnityEngine;
using System.Collections;

public class Door : OpenCloseChild {
	
	public bool isLocked = false;
	
	public void Awake() {
		isOpen = false;
		if(pops == null) {
			SetParent();
		}
	}
	
	public override void SetParent() {
        Transform nextTransform = this.transform.parent;

        while (pops == null && nextTransform != null) {
            pops = nextTransform.GetComponent<DoorParent>();
            nextTransform = this.transform.parent;
        }
	} 
	
	public void OnMouseDown() {
		if(!isLocked) {
			handleAnimation();
		} else {
			Debug.Log("can not open, it is locked");
		}
	}
}
