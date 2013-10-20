using UnityEngine;
using System.Collections;

public class MouseManager : MonoBehaviour {

	public int DEFAULT_CURSOR = 0;
	public int INTERACT_CURSOR = 1;
	public int COLLECT_CURSOR = 2;
	public int MAGNIFY_CURSOR = 3;
	public int PUSH_CURSOR = 4;

	public Texture2D[] cursors;
	public string[] cursorDescriptions = new string[5] { 
		"Default",
		"Object can be interacted with",
		"Object can collected",
		"Object can be inspected for more information",
		"Object can be pushed or pulled"
	};
	
	public float cursorWidth = 50;
	public float cursorHeight = 50;

	public int cursorType = 0;
	
	private static MouseManager _instance;
	private MouseManager() {}
	
	public static MouseManager Instance {
		get {
			if(_instance == null) {
	                _instance = GameObject.FindObjectOfType(typeof(MouseManager)) as MouseManager;      
			}
			return _instance;
		}
	}

	public void Start() {
//		Debug.Log("MouseManager/Start");
		Screen.showCursor = false;
	}

	public void init() {
 		cursorDescriptions = new string[4]; 
	}

	public void drawCursor() {
		GUI.DrawTexture(new Rect(Input.mousePosition.x - cursorWidth / 2,(Screen.height - Input.mousePosition.y) - cursorHeight / 2, cursorWidth, cursorHeight), cursors[cursorType]);
	}

	public void setCursorType(int type) {
		cursorType = type;
	}
}
