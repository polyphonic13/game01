using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArmatureTrigger : InteractiveElement {
	public ArmatureParent pops;
	public AnimationClip mainClip;

	public Transform parentBone;

	void Awake() {
		init ();
	}

	public void OnMouseDown() {
		var difference = Vector3.Distance(Camera.mainCamera.gameObject.transform.position, this.transform.position);
		if(difference <= interactDistance) {
			handleAnimation();
		}
	}
	
	public virtual void handleAnimation() {
//		Debug.Log("ArmatureTrigger[ " + this.name + " ]/handleAnimation");
		sendAnimationToPops(mainClip.name, parentBone);
	}
	
	public void sendAnimationToPops(string clipName, Transform bone) {
//		Debug.Log("ArmatureTrigger[ " + this.name + " ]/sendAnimationToPops, clipName = " + clipName);
		pops.playAnimation(clipName, bone);
	}
}
