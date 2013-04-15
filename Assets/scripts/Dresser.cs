using UnityEngine;
using System.Collections;

public class Dresser : OpenCloseParent {
	
	void Awake() {
		currentOpen = null;
	}
	
	public override void OpenChild(OpenCloseChild child) {
		Debug.Log("OpenDrawer, currentOpen = " + currentOpen + ", child = " + child.name);
		if(currentOpen != null && currentOpen != child) {
			CloseChild(currentOpen);
			//yield return new WaitForSeconds(this.animation[currentOpen.closeClipName].length);
		}
		PlayDrawerAnimation(child.openClipName);		
		currentOpen = child;
	}
	
	public override void CloseChild(OpenCloseChild child) {
		PlayDrawerAnimation(child.closeClipName);
		child.isOpen = false;
		currentOpen = null;
	}
	
	private void PlayDrawerAnimation(string clip) {
		this.transform.animation.Play(clip);	
	}
}
