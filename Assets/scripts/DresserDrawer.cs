using UnityEngine;
using System.Collections;

public class DresserDrawer : OpenCloseChild {
	
	public void Awake() {
		isOpen = false;
		if(pops == null) {
			SetParent();
		}
	}
	
	public override void SetParent() {
        Transform nextTransform = this.transform.parent;

        while (pops == null && nextTransform != null) {
            pops = nextTransform.GetComponent<Dresser>();
            nextTransform = this.transform.parent;
        }
	} 
	
}
