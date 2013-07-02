using UnityEngine;
using System.Collections;

public class AnimatedParent : MonoBehaviour {
	
	public float startX;
	public float startY;
	public float startZ;
	
	// Use this for initialization
	void Start () {
		this.startX = this.transform.position.x;
		this.startY = this.transform.position.y;
		this.startZ = this.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		var updatedX = this.transform.position.x;
		var updatedY = this.transform.position.y;
		var updatedZ = this.transform.position.z;
		if( updatedX != this.startX || updatedY != this.startY || updatedZ != this.startZ) {
			Debug.Log( this.name + " updated: x = " + updatedX + ", y = " + updatedY + ", z = " + updatedZ);
			this.startX = updatedX;
			this.startY = updatedY;
			this.startZ = updatedZ;
		}
	}
}
