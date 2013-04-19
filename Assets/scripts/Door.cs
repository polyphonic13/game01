using UnityEngine;
using System.Collections;

public class Door : OpenCloseChild {
	
	public void Awake() {
		isOpen = false;
		if(pops == null) {
			SetParent();
		}
	}
	
	public override void SetParent() {
        Transform nextTransform = this.transform.parent;

        while (pops == null && nextTransform != null) {
            pops = nextTransform.GetComponent<Hall>();
            nextTransform = this.transform.parent;
        }
	} 
	
}
