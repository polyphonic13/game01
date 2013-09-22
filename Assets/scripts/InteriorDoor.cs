using UnityEngine;
using System.Collections;

public class InteriorDoor : ArmatureParent {
	public Texture doorTexture;
	public Texture frameTexture;

	void Awake() {
		var door = transform.Find("door");
		var frame = transform.Find("frame");
//		Debug.Log ("door = " + door + ", frame = " + frame);
		door.renderer.material.mainTexture = doorTexture;
		frame.renderer.material.mainTexture = frameTexture;
	}
}
