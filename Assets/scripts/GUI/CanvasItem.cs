using UnityEngine;
using System.Collections;

public class CanvasItem : MonoBehaviour {

	public bool show = false;
	public bool isShowing = false;

	private CanvasGroup _group;

	void Awake() {
		initCanvasItem ();
	}

	public void initCanvasItem() {
//		Debug.Log ("CanvasItem[" + gameObject.name + "]/init, setting active to false");
		_group = gameObject.GetComponent<CanvasGroup>();
		_group.alpha = 0;
	}
	
	public void showHide(bool enable) {
		Debug.Log ("CanvasItem[ " + this.name + " ]/enableItem, enable = " + enable + ", show = " + show + ", isShowing = " + isShowing);
		isShowing = enable;
		_group.alpha = (enable) ? 1 : 0;
	}
}
