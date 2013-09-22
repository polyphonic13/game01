using UnityEngine;
using System.Collections;

public class MovableChild : CollectableItem {
	
	public GameObject pops;
	public string roomName;
	Vector3 popsPosition;
	
	// Use this for initialization
	void Awake () {
				init (2);
		this.enabled = false;
		popsPosition = pops.transform.position;
//		EventCenter.Instance.roomEntered += roomEntered;
		var player = GameObject.Find("player").GetComponent<Player>();
		player.roomEntered += roomEntered;
//		player.inventory.itemCollected += itemCollected;
	}
	
	void roomEntered(string room) {
		Debug.Log(this.name + "/roomEntered, room = " + room + ", collected = " + this.collected);
		if(!this.collected) {
			if(room == roomName) {
				this.enabled = true;
			} else {
				if(this.enabled) {
					this.enabled = false;
				}
			}
		} else {
			var player = GameObject.Find("player").GetComponent<Player>();
			player.roomEntered -= roomEntered;
			this.enabled = false;
		}
	}
/*	
	void itemCollected(string itemName) {
		Debug.Log(this.name + "/itemCollected, itemName = " + itemName);
		if(itemName == this.name) {
			this.enabled = false;
			var player = GameObject.Find("player").GetComponent<Player>();
			player.roomEntered -= roomEntered;
			player.inventory.itemCollected -= itemCollected;
		}
	}
*/	
	// Update is called once per frame
	void Update () {
		// Debug.Log(this.name + "/Update, popsPosition = " + popsPosition);
		var updatedPosition = popsPosition;
		if(updatedPosition != popsPosition) {
			popsPosition = updatedPosition;
			var difference = popsPosition - updatedPosition;
			this.transform.position += difference;
			Debug.Log(this.name + " position updated to: " + this.transform.position + ", popsPosition = " + popsPosition + ", difference = " + difference);
		}
	}
}
