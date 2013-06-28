using UnityEngine;
using System.Collections;

public class Notification {
	public bool hasNote;
	public string content;

	GUIStyle _style;
	
	public void init(GUIStyle style) {
		_style = style;
		// Debug.Log ("Notification/init, _style = " + _style);
		hasNote = false;
	}
	
	public void AddNote(string msg) {
		// Debug.Log("Notification/draw, msg = " + msg);
		var player = GameObject.Find("player").GetComponent<Player>();
		player.EnablePlayer(false);
		content = msg;
		hasNote = true;
	}
	
	public void Destroy() {
		// Debug.Log("Notification/destroy");	
		hasNote = false;
		content = "";
	}

	public void DrawNote() {
		GUI.Box(new Rect((Screen.width/2 - 250), (Screen.height/2 - 50), 500, 100), content /*, _style */);
		if(GUI.Button(new Rect((Screen.width/2 - 250), (Screen.height/2 - 100), 500, 50), "Close" /*, _style */)) {
			this.Destroy();
			var player = GameObject.Find("player").GetComponent<Player>();
			player.EnablePlayer(true);
		}
	}

}
