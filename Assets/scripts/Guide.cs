using UnityEngine;
using System.Collections;

public class Guide : InteractiveElement {

	public Material lenseOn;
	public Material lenseOff;
	public Material innardsOn;
	public Material innardsOff;

	public bool isActive { get; set; }

	private const string DEFAULT_CLIP = "guide01_default";
	private const string ARMS_OPEN_CLIP = "guide01_arms_open";
	private const string ARMS_CLOSE_CLIP = "guide01_arms_close";

	private Transform _lens;
	private Transform _innards;

	private Animation _animation;

	void Awake() {
		initGuide();
	}

	public void initGuide() {
		isActive = false;
		_lens = this.transform.Search("lens");
		_innards = this.transform.Search("innards");
		_animation = GetComponent<Animation>();
		_playClip(DEFAULT_CLIP);
		deactivate();
		Debug.Log("Guide/initGuide, lens = " + _lens + ", _innards = " + _innards);
		init ();
	}
	 
	public void OnMouseDown() {
		Debug.Log("Guide/OnMouseDown");
		toggleActivated();
	}

	public void toggleActivated() {
		if(isActive) {
			deactivate();
		} else {
			activate();
		}
		isActive = !isActive;
	}

	public void activate() {
		Debug.Log("Guide/activate");
		_applyOnMaterials();
		_playClip(ARMS_OPEN_CLIP);
	}

	public void deactivate() {
		Debug.Log("Guide/deactivate");
		_applyOffMaterials();
		_playClip(ARMS_CLOSE_CLIP);
	}

	private void _applyOffMaterials() {
		Debug.Log("Guide/_applyOffMaterials");
		_lens.renderer.material = lenseOff;
		_innards.renderer.material = innardsOff;
	}

	private void _applyOnMaterials() {
		Debug.Log("Guide/_applyOnMaterials");
		_lens.renderer.material = lenseOn;
		_innards.renderer.material = innardsOn;
	}

	private void _playClip(string clip) {
		_animation[clip].wrapMode = WrapMode.Once;
		_animation.Play(clip);
	}
}
