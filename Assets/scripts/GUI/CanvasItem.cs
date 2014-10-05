using UnityEngine;
using System.Collections;

public class CanvasItem {

	public bool show { get; set; }
	public bool isShowing = false;

	private GameObject canvas;

	public void init(string canvasName) {
		canvas = GameObject.Find (canvasName);
		canvas.SetActive (false);

	}
	
	public void enableItem(bool enable) {
		isShowing = enable;
		canvas.SetActive (enable);
	}
}
