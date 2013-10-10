using UnityEngine;
using System.Collections;

public class OpenCloseArmatureTrigger : ArmatureTrigger {

	public AnimationClip closeClip;
	public bool isOpen = false;

	void Awake() {
		init();
	}

	public override void handleAnimation() {
		handleOpenClose();
	}
	
	public void handleOpenClose() {
//		Debug.Log("OpenCloseArmatureChild[ " + this.name + " ]/handleOpenClose, isOpen = " + isOpen);
		if(isOpen) {
			sendAnimationToPops(closeClip.name, parentBone);
		} else {
			sendAnimationToPops(mainClip.name, parentBone);
		}
		isOpen = !isOpen;
	}
}
