using UnityEngine;
using System.Collections;

public class Dresser : OpenCloseParent {
	
	void Awake() {
		openChild = null;
	}
	
	public override void ChildOpen(OpenCloseChild child) {
		Debug.Log("OpenDrawer, openChild = " + openChild + ", child = " + child.name);
		if(openChild != null && openChild != child) {
			ChildClose(openChild);
		}
		PlayDrawerAnimation(child.openClipName);		
		openChild = child;
	}
	
	public override void ChildClose(OpenCloseChild child) {
		PlayDrawerAnimation(child.closeClipName);
		child.isOpen = false;
		openChild = null;
	}
	
	private void PlayDrawerAnimation(string clip) {
		this.transform.animation.Play(clip);	
	}
}
