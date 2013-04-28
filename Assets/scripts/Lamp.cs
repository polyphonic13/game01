using UnityEngine;
using System.Collections;

public class Lamp : MonoBehaviour {

	Light bulb; 
	
	void Awake() {
		bulb = this.transform.Search("light_bulb").light;
		bulb.enabled = false;
	}

	public void OnMouseDown() {
		Debug.Log("Lamp/on mouse down");
		bulb.enabled = !bulb.enabled;	
	}
}
