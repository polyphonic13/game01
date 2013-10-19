using UnityEngine;
using System.Collections;

public class ArmatureParent : MonoBehaviour {

	public AnimationClip defaultAnimation; 
	
	public Animation animation { get; set; }
	
	public void playAnimation(string clip, Transform bone = null) {
//		Debug.Log("ArmatureParent[ " + this.name + " ]/playAnimation, clip = " + clip + ", bone = " + bone + ", animation = " + this.animation);
		if(bone != null) {
			this.animation [clip].AddMixingTransform(bone);
		}
		this.animation [clip].wrapMode = WrapMode.Once;
		this.animation.Play(clip);
	}

	void Awake() {
		init();
	}
	
	public virtual void init() {
		this.animation = GetComponent<Animation>();
//		Debug.Log("ArmatureParent[ " + this.name + " ]/init, animation = " + this.animation);
		playDefaultAnimation();
	}
	
	public void playDefaultAnimation() {
//		gameObject.SetActive(false);

		if(defaultAnimation != null) {
//			Debug.Log("ArmatureParent/Start, defaultAnimation = " + defaultAnimation.name);
			this.animation [defaultAnimation.name].layer = 0;
			this.animation[defaultAnimation.name].wrapMode = WrapMode.Once;
			this.animation.Play(defaultAnimation.name);
		}
	}
}
