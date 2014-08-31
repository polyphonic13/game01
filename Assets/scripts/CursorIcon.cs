using UnityEngine;
using System.Collections;

public class CursorIcon : MonoBehaviour {

	public Texture defaultIcon;
	public Texture activeIcon;

	public OVRCamera parentCam;

	// Use this for initialization
	void Start () {
		this.gameObject.renderer.material.SetTexture ("_MainTex", defaultIcon);
		if(parentCam != null) {
			this.gameObject.transform.parent = parentCam.transform;
		}
	}
	// Update is called once per frame
	void Update () {
	
	}

	public void updateActiveIcon(bool active) {
		if(active) {
			this.gameObject.renderer.material.SetTexture("_MainTex", activeIcon);
		} else {
			this.gameObject.renderer.material.SetTexture("_MainTex", defaultIcon);
		}
	}
}
