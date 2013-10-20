using UnityEngine;
using System.Collections;

public class Menu {

	public bool showMenu { get; set; }
	
	private const string MENU_TITLE = "Menu";
	private const string CONTROLS = "Controls";
	private const string ICONS = "Icons";
	
	private const float ICON_WIDTH = 50;
	private const float ICON_DESCRIPTION_WIDTH = 400;
	private const float ICON_DESCRIPTION_HEIGHT = 50;
	
	private GUIStyle _style;
	
	public void init(GUIStyle style) {
		_style = style;
	}
	
	public void draw() {
		EventCenter.Instance.enablePlayer(false);
		drawBackground("Menu");
		Rect columnBg = new Rect(0, 30, Screen.width/2 - 60, Screen.height - 60);
		GUI.Box(new Rect(10, columnBg.y, columnBg.width, columnBg.height), CONTROLS);
		GUI.Box(new Rect(Screen.width/2 + 30, columnBg.y, columnBg.width, columnBg.height), ICONS);
		drawCursors();
	}
	
	public void drawCursors() {
		MouseManager mouseManager = MouseManager.Instance;
		string[] descriptions = mouseManager.getCursorDescriptions();
		Texture2D[] icons = mouseManager.cursors;
		Debug.Log("Menu/drawCursors, descriptions.length = " + descriptions.Length);

		for(int i = 0; i < descriptions.Length; i++) {
		    GUI.skin.label.alignment = TextAnchor.LowerLeft;
			GUI.DrawTexture (new Rect (Screen.width/2 + 100, ICON_DESCRIPTION_HEIGHT + (i* (ICON_DESCRIPTION_HEIGHT + 10)), ICON_WIDTH, ICON_DESCRIPTION_HEIGHT), icons[i]);
			GUI.Label(new Rect(Screen.width/2 + 200, ICON_DESCRIPTION_HEIGHT + (i* (ICON_DESCRIPTION_HEIGHT + 10)), ICON_DESCRIPTION_WIDTH, ICON_DESCRIPTION_HEIGHT), descriptions[i]);
			
		}
	}
	
	public void drawBackground(string title) {
		GUI.Box(new Rect(5, 5, Screen.width - 10, Screen.height - 10), MENU_TITLE /*, _style */);
	}
	
	public void destroy() {
		// Debug.Log("Notification/destroy");	
		this.showMenu = false;
		EventCenter.Instance.enablePlayer(true);
	}

}
