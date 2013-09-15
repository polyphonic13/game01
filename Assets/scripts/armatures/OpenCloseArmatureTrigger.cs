using UnityEngine;
using System.Collections;

public class OpenCloseArmatureTrigger : ArmatureTrigger {

	public AnimationClip closeClip;
	public bool isOpen = false;

	public override void handleAnimation() {
		handleOpenClose();
	}
	
	public void handleOpenClose() {
		Debug.Log("OpenCloseArmatureChild[ " + this.name + " ]/handleOpenClose, isOpen = " + isOpen);
		if(isOpen) {
			sendAnimationToPops(closeClip.name);
		} else {
			sendAnimationToPops(mainClip.name);
		}
		isOpen = !isOpen;
	}
}
