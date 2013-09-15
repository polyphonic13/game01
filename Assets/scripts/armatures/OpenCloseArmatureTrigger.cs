using UnityEngine;
using System.Collections;

public class OpenCloseArmatureTrigger : ArmatureTrigger {

	public string closeClipName;
	public bool isOpen = false;

	public override void handleAnimation() {
		handleOpenClose();
	}
	
	public void handleOpenClose() {
		Debug.Log("OpenCloseArmatureChild[ " + this.name + " ]/handleOpenClose, isOpen = " + isOpen);
		if(isOpen) {
			sendAnimationToPops(closeClipName);
		} else {
			sendAnimationToPops(mainClipName);
		}
		isOpen = !isOpen;
	}
}
