using UnityEngine;
using System.Collections;

public class TouchableChild : MonoBehaviour {
	
	public delegate void TouchHandler(GameObject touchedChild);

	/*
	public OnTouchedDelegate touchDelegate;
	public OnTouchDelegate TouchDelegate {
		set { touchDelegate = value; }
	}
	*/
	public event TouchHandler onChildTouched;
	
	public void childTouched(GameObject child) {
		if(onChildTouched != null) {
			onChildTouched(child);
		}
	}
	
	void OnCollisionEnter(Collision target) {
		childTouched(target.transform.gameObject);
	}
}
