using UnityEngine;
using System.Collections;

public class Notification {

	private GUIStyle _style;
	private string _content;

	public bool showNote { get; set; };

	public void init(GUIStyle style) {
		_style = style;
		// Debug.Log ("Notification/init, _style = " + _style);
		this.showNote = false;
	}
	
	public void addNote(string msg) {
		// Debug.Log("Notification/draw, msg = " + msg);
		var player = GameObject.Find("player").GetComponent<Player>();
		player.enablePlayer(false);
		_content = msg;
		this.showNote = true;
	}
	
	public void destroy() {
		// Debug.Log("Notification/destroy");	
		this.showNote = false;
		_content = "";
		var player = GameObject.Find("player").GetComponent<Player>();
		player.enablePlayer(true);
	}

	public void drawNote() {
		GUI.Box(new Rect((Screen.width/2 - 250), (Screen.height/2 - 50), 500, 100), _content /*, _style */);
		if(GUI.Button(new Rect((Screen.width/2 + 150), (Screen.height/2 - 70), 100, 20), "Close" /*, _style */)) {
			this.destroy();
		}
	}

}
