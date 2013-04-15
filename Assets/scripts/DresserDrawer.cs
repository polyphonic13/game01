using UnityEngine;
using System.Collections;

public class DresserDrawer : OpenCloseChild {
	
	public void Awake() {
		isOpen = false;
		setParent();
	}
	
	private void setParent() {
        Transform nextTransform = this.transform.parent;

        while (parent == null && nextTransform != null) {
            parent = nextTransform.GetComponent<Dresser>();
            nextTransform = this.transform.parent;
        }
	} 
	
	private void OnMouseDown() {
		//Debug.Log("DresserDrawer/OnMouseDown, name = " + this.name);
		if(isOpen) {
			parent.CloseChild(this);
			isOpen = false;
		} else {
			parent.OpenChild(this);
			isOpen = true;
		}
	}
}
