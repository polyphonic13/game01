using UnityEngine;
using System.Collections;

public class Bathroom : MonoBehaviour {
	
	private BathroomDoor door;
	// Use this for initialization
	void Start () {
	
	}
	
	void Awake () {
		door = this.GetComponentInChildren<BathroomDoor>();	
	}
	
	// Update is called once per frame
	void Update () {
	}
	
}
