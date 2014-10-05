using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Notification : CanvasItem {

	public const string CANVAS_NAME = "notificationUI";
	public const string TEXT_NAME = "notificationText";

	private string _content;
	
	private EventCenter _eventCenter;

	private Text notificationText;

	private bool _zoomNote = false;
	
	public void init() {
		// Debug.Log("Notification/init, _style = " + _style);
		GameObject textComponent = GameObject.Find (TEXT_NAME);
		if(textComponent != null) {
			notificationText = textComponent.GetComponent<Text>();
			Debug.Log("notificationText = " + notificationText);
		}
		_eventCenter = EventCenter.Instance;
		_eventCenter.onAddNote += this.onAddNote;
		_eventCenter.onRemoveNote += this.onRemoveNote;
		base.init(CANVAS_NAME);
	}
	
    public void onAddNote(string msg, bool zoom = false) {
        addNote(msg, zoom);
    }
	
	public void onRemoveNote(string msg = "", bool zoom = false) {
		destroy();
	}
	
	public void addNote(string msg, bool zoom = false) {
		// Debug.Log("Notification/draw, msg = " + msg);
		notificationText.text = msg;
		_zoomNote = zoom;

		if(_zoomNote) {
			_eventCenter.zoomCamera(true);
		}
		_eventCenter.enablePlayer(false);
		this.show = true;
	}
	
	public void destroy() {
		// Debug.Log("Notification/destroy");	
		this.show = false;
		notificationText.text = "";
		_eventCenter.enablePlayer(true);
	}

}
