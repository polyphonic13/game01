using UnityEngine;
using System.Collections;

public class ArmatureParent : MonoBehaviour {

	public AnimationClip defaultAnimation; 
	
	public Animation animation { get; set; }
	
	public void playAnimation(string clip, Transform bone = null) {
//		Debug.Log("ArmatureParent[ " + this.name + " ]/playAnimation, clip = " + clip + ", bone = " + bone);
		if(bone != null) {
			animation [clip].AddMixingTransform(bone);
		}
		animation [clip].wrapMode = WrapMode.Once;
		animation.Play(clip);
	}

	void Awake() {
		init();
	}
	
	public virtual void init() {
		animation = GetComponent<Animation>();
		playerDefaultAnimation();
	}
	
	public void playerDefaultAnimation() {
//		gameObject.SetActive(false);

		if(defaultAnimation != null) {
//			Debug.Log("ArmatureParent/Start, defaultAnimation = " + defaultAnimation.name);
			animation [defaultAnimation.name].layer = 0;
			animation[defaultAnimation.name].wrapMode = WrapMode.Once;
			animation.Play(defaultAnimation.name);
		}
	}
}
