using UnityEngine;
using System.Collections;

public class MouseManager : MonoBehaviour {

	public Texture2D defaultCursor;
	public Texture2D handCursor;
	public Texture2D pinchCursor;
	public float cursorWidth = 50;
	public float cursorHeight = 50;

	public int cursorType = 0;

	public void Start() {
		Debug.Log ("MouseManager/Start");
		Screen.showCursor = false;
	}

	public void init() {

	}

	void OnGui() {
		Debug.Log ("MouseManager/OnGui");
	}

	public void drawCursor() {
		Texture2D cursorToDraw = defaultCursor;
		if (cursorType > 0) {
			switch (cursorType) {
				case 1:
					cursorToDraw = handCursor;
					break;
				case 2:
					cursorToDraw = pinchCursor;
					break;
			}
		}
		GUI.DrawTexture(new Rect(Input.mousePosition.x - cursorWidth / 2, (Screen.height - Input.mousePosition.y) - cursorHeight / 2, cursorWidth, cursorHeight), cursorToDraw);
	}

	public void setCursorType(int type) {
		cursorType = type;
	}
}
