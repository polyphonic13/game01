using UnityEngine;
using System.Collections;

public class Room : MonoBehaviour {
	// Use this for initialization
	public string roomName = "";
	
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	/*
	void OnTriggerEnter(Collider tgt) {
		Debug.Log("Room/OnTriggerEnter, tgt = " + tgt);
		Debug.Log("EventCenter = " + EventCenter.Instance);
		EventCenter.Instance.roomEntered(this.roomName);
	}
	*/
}
