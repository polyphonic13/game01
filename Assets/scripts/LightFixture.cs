using UnityEngine;
using System.Collections;

public class LightFixture : OnOffLight {
	
	private Component[] _onOffSelfIllums;
	
	void Awake() {
		initLamp();
	}

	void initLamp() {
		_onOffSelfIllums = GetComponentsInChildren<OnOffSelfIllum>();
		if(_onOffSelfIllums != null) {
			_toggleSelfIllums(true);
		}
		initOnOffLight();
	}
	
	public override void toggle() {
		this.toggleBulb();
		if(_onOffSelfIllums != null) {
			if(this.getIsOn()) {
				_toggleSelfIllums(false);
			} else {
				_toggleSelfIllums(true);
			}
		}
	}
	
	private void _toggleSelfIllums(bool turnOff) {
		//for(int i = 0; i < _onOffSelfIllums.Count; i++) {
		foreach(OnOffSelfIllum onOffSelfIllum in _onOffSelfIllums) {
			if(turnOff) {
				_turnOffSelfIllum(onOffSelfIllum);
			} else {
				_turnOnSelfIllum(onOffSelfIllum);
			}
		}
	}
	
	private void _turnOffSelfIllum(OnOffSelfIllum onOffSelfIllum) {
		onOffSelfIllum.gameObject.transform.renderer.material = onOffSelfIllum.offMaterial;
	}

	private void _turnOnSelfIllum(OnOffSelfIllum onOffSelfIllum) {
		onOffSelfIllum.gameObject.transform.renderer.material = onOffSelfIllum.onMaterial;
	}
}
