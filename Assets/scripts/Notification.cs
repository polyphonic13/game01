using UnityEngine;
using System.Collections;

public class Notification {
	public bool hasNote;
	public string content;

	private GUI gb;
	
	public void init() {
		hasNote = false;
	}
	
	public void AddNote(string msg) {
		Debug.Log("Notification/draw, msg = " + msg);
		content = msg;
		hasNote = true;
	}
	
	public void Destroy() {
		Debug.Log("Notification/destroy");	
		hasNote = false;
		content = "";
	}

	public void DrawNote() {
		if(hasNote) {
			GUI.Box(new Rect(100, 100, 500, 100), content);
			if(GUILayout.Button("Close")) {
                this.Destroy();
            }

		}
	}

}
