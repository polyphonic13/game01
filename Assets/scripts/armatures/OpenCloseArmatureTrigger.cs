using UnityEngine;
using System.Collections;

public class OpenCloseArmatureTrigger : ArmatureTrigger {

	public AnimationClip closeClip;

	public bool isOpen { get; set; };

	void Awake() {
		init();
		this.isOpen = false;
	}

	public override void handleAnimation() {
		handleOpenClose();
	}
	
	public void handleOpenClose() {
		if(this.isOpen) {
			sendAnimationToPops(closeClip.name, parentBone);
		} else {
			sendAnimationToPops(mainClip.name, parentBone);
		}
		this.isOpen = !this.isOpen;
	}
}
