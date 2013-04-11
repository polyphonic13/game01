using UnityEngine;
using System.Collections;

public class DoorAnimation : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnMouseDown() {
		Debug.Log ( "Mouse down on " + this.name );
		gameObject.animation.Play( "door_open" );	
	}
	
	void OnTriggerEnter(Collider collider) {
		Debug.Log ( "Door triggered" );
	}
}
