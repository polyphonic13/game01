using UnityEngine;
using System.Collections;

public class LockableParent : OpenCloseParent {

	public override void OpenChild(OpenCloseChild child) {
		playAnimation(child.openClipName);		
		currentOpen = child;
	}
	
	public override void CloseChild(OpenCloseChild child) {
		playAnimation(child.closeClipName);
		currentOpen = null;
	}
	
}
