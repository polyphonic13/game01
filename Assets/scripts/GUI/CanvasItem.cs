using UnityEngine;
using System.Collections;

public class CanvasItem : MonoBehaviour {

	public bool show = false;
	public bool isShowing = false;

//	public GameObject canvas;

	void Awake() {
//		canvas = GameObject.Find (canvasName);
//		canvas.SetActive (false);
		initCanvasItem ();
	}

	public void initCanvasItem() {
		Debug.Log ("CanvasItem[" + gameObject.name + "]/init, setting active to false");
		this.gameObject.SetActive (false);
	}
	
	public void enableItem(bool enable) {
		Debug.Log ("CanvasItem/enableItem, enable = " + enable + ", show = " + show + ", isShowing = " + isShowing);
		isShowing = enable;
//		canvas.SetActive (enable);
		this.gameObject.SetActive (enable);
	}
}
