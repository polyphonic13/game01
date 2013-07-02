using UnityEngine;
using System.Collections;

public class MovableChild : MonoBehaviour {
	
	public GameObject pops;
	Vector3 popsPosition;
	
	// Use this for initialization
	void Awake () {
		popsPosition = pops.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		var updatedPosition = pops.transform.position;
		if(updatedPosition != popsPosition) {
			popsPosition = updatedPosition;
			var difference = popsPosition - updatedPosition;
			this.transform.position += difference;
			Debug.Log(this.name + " position updated to: " + this.transform.position + ", popsPosition = " + popsPosition + ", difference = " + difference);
		}
	}
}
