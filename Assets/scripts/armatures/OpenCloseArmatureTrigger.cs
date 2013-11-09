using UnityEngine;
using System.Collections;

public class OpenCloseArmatureTrigger : ArmatureTrigger {

	public AnimationClip closeClip;

	public bool isOpen { get; set; }

	void Awake() {
		initOpenCloseArmatureTrigger();
		init();
	}
	
	public void initOpenCloseArmatureTrigger() {
		this.pops.onAnimationPlayed += this.onAnimatinoPlayed;
		this.isOpen = false;
	}
	
	public override void handleAnimation() {
		handleOpenClose();
	}
	
	public void handleOpenClose() {
//		Debug.Log("OpenCloseArmatureChild[ " + this.name + " ]/handleOpenClose, this.isOpen = " + this.isOpen);
		if(this.isOpen) {
			sendAnimationToPops(closeClip.name, parentBone);
		} else {
			sendAnimationToPops(mainClip.name, parentBone);
		}
		this.isOpen = !this.isOpen;
	}
	
	public void onAnimatinoPlayed(Transform bone) {
		if(this.isOpen) {
			Debug.Log("OpenCloseArmatureTrigger[ " + this.name + " ]/onAnimationPlayed, isOpen = " + this.isOpen + ", bone = " + bone.name + ", parentBone = " + this.parentBone.name);
			if(bone.name != this.parentBone.name) {
				sendAnimationToPops(closeClip.name, parentBone);
				this.isOpen = false;
			}
		}
	}
	
}
