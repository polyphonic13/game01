using UnityEngine;
using System.Collections;

public class DresserDrawer : MonoBehaviour {
	
	public int drawerIdx;
	bool isOpen = false;
	Dresser parent;
	
	public void Awake() {
		setParent();
	}
	
	private void setParent() {
        Transform nextTransform = this.transform.parent;

        while (parent == null && nextTransform != null)
        {
            parent = nextTransform.GetComponent<Dresser>();
            nextTransform = this.transform.parent;
        }
	} 
	
	private void OnMouseDown() {
		if(isOpen) {
			parent.ChildClose(drawerIdx);
			isOpen = false;
		} else {
			parent.ChildOpen(drawerIdx);
			isOpen = true;
		}
	}
}
