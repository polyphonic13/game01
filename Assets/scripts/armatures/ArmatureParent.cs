using UnityEngine;
using System.Collections;

public class ArmatureParent : MonoBehaviour {

	public AnimationClip defaultAnimation; 
	
	private Animation _animation;
	
	public void playAnimation(string clip, Transform bone = null) {
		Debug.Log ("ArmatureParent[ " + this.name + " ]/playAnimation, clip = " + clip + ", bone = " + bone);
		if (bone != null) {
			_animation [clip].AddMixingTransform (bone);
		}
		_animation [clip].wrapMode = WrapMode.Once;
		_animation.Play (clip);
	}
	
	void Start() {
		_animation = GetComponent<Animation>();
		if(defaultAnimation != null) {
			Debug.Log("ArmatureParent/Start, defaultAnimation = " + defaultAnimation.name);
			_animation [defaultAnimation.name].layer = 0;
			_animation[defaultAnimation.name].wrapMode = WrapMode.Loop;
			_animation.Play(defaultAnimation.name);
		}
	}
}
