using UnityEngine;
using System.Collections;

public class Notification {
	public bool showNote;
	public string content;

	GUIStyle _style;
	
	public void init(GUIStyle style) {
		_style = style;
		// Debug.Log ("Notification/init, _style = " + _style);
		showNote = false;
	}
	
	public void addNote(string msg) {
		// Debug.Log("Notification/draw, msg = " + msg);
		var player = GameObject.Find("player").GetComponent<Player>();
		player.enablePlayer(false);
		content = msg;
		showNote = true;
	}
	
	public void destroy() {
		// Debug.Log("Notification/destroy");	
		showNote = false;
		content = "";
		var player = GameObject.Find("player").GetComponent<Player>();
		player.enablePlayer(true);
	}

	public void drawNote() {
		GUI.Box(new Rect((Screen.width/2 - 250), (Screen.height/2 - 50), 500, 100), content /*, _style */);
		if(GUI.Button(new Rect((Screen.width/2 + 150), (Screen.height/2 - 70), 100, 20), "Close" /*, _style */)) {
			this.destroy();
		}
	}

}
