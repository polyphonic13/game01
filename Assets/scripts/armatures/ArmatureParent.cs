using UnityEngine;
using System.Collections;

public class ArmatureParent : MonoBehaviour {

	public AnimationClip defaultAnimation; 
	
	private Animation _animation;
	
	public void playAnimation(string clip) {
		_animation [clip].layer = 10;
		_animation [clip].blendMode = AnimationBlendMode.Blend;
		_animation[clip].wrapMode = WrapMode.Once;
		_animation.Play(clip);
	}
	
	void Start() {
		_animation = GetComponent<Animation>();
		Debug.Log("ArmatureParent/Start, defaultAnimation = " + defaultAnimation.name);
		if(defaultAnimation != null) {
			_animation [defaultAnimation.name].layer = 0;
			_animation[defaultAnimation.name].wrapMode = WrapMode.Once;
			_animation.Play(defaultAnimation.name);
		}
	}
}
