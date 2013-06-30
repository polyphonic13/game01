using UnityEngine;
using System.Collections;

public class LockableChildHardware : MonoBehaviour {
	public LockableChild pops;
	
	public void OnMouseDown() {
		Debug.Log("MouseChild/OnMouseDown");
		pops.OnMouseDown();
	}
}
