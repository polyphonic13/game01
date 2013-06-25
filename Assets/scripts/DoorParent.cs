using UnityEngine;
using System.Collections;

public class DoorParent : OpenCloseParent {

	public override void OpenChild(OpenCloseChild child) {
		PlayAnimation(child.openClipName);		
		currentOpen = child;
	}
	
	public override void CloseChild(OpenCloseChild child) {
		PlayAnimation(child.closeClipName);
		currentOpen = null;
	}
}
