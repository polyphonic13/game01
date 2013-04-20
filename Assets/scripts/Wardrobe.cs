using UnityEngine;
using System.Collections;

public class Wardrobe : OpenCloseParent {

	void Awake() {
		currentOpen = null;
	}

	public override void OpenChild(OpenCloseChild child) {
//		Debug.Log("OpenDrawer, currentOpen = " + currentOpen + ", child = " + child.name);
		if(currentOpen != null && currentOpen != child) {
			CloseChild(currentOpen);
		}
		PlayAnimation(child.openClipName);		
		currentOpen = child;
	}
	
	public override void CloseChild(OpenCloseChild child) {
		PlayAnimation(child.closeClipName);
		child.isOpen = false;
		currentOpen = null;
	}
}
