using UnityEngine;
using System.Collections;

public class MovableChild : MonoBehaviour {
	
	public GameObject pops;
	public string roomName;
	Vector3 popsPosition;
	
	// Use this for initialization
	void Awake () {
		this.enabled = false;
		popsPosition = pops.transform.position;
//		EventCenter.Instance.roomEntered += roomEntered;
		var player = GameObject.Find("player").GetComponent<Player>();
		player.roomEntered += roomEntered;
	}
	
	void roomEntered(string room) {
		Debug.Log(this.name + "/roomEntered, room = " + room);
		if(room == roomName) {
			this.enabled = true;
		} else {
			if(this.enabled) {
				this.enabled = false;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(this.name + "/Update, popsPosition = " + popsPosition);
		var updatedPosition = popsPosition;
		if(updatedPosition != popsPosition) {
			popsPosition = updatedPosition;
			var difference = popsPosition - updatedPosition;
			this.transform.position += difference;
			Debug.Log(this.name + " position updated to: " + this.transform.position + ", popsPosition = " + popsPosition + ", difference = " + difference);
		}
	}
}
