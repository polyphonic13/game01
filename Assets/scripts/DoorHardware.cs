using UnityEngine;
using System.Collections;

public class DoorHardware : MonoBehaviour {
	public Door pops;
	
	public void OnMouseDown() {
		Debug.Log("MouseChild/OnMouseDown");
		pops.OnMouseDown();
	}
}
