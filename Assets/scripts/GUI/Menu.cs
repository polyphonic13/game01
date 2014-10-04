using UnityEngine;
using System.Collections;

public class Menu {

	public bool showMenu { get; set; }
	public bool isShowing = false;

	private string[] _controlKeys =  new string [9] {
		"mouse",
		"w",
		"s",
		"a",
		"d",
		"q",
		"m",
		"f",
		"x"
	};
	
	private string[] _controlDescriptions = new string[9] {
		"Look / move direction",
		"Move forward",
		"Move backwards",
		"Move left",
		"Move right",
		"Open / close inventory",
		"Open / close menu",
		"Activate / Deactivate flashlight",
		"Drop equipped item"
	};
	
	private const string MENU_TITLE = "Menu";
	private const string CONTROLS = "Controls";
	private const string ICONS = "Icons";
	
	private const float DESCRIPTION_WIDTH = 400;

	private const float CONTROL_DESCRIPTION_HEIGHT = 20;
	
	private const float ICON_WIDTH = 50;
	private const float ICON_DESCRIPTION_HEIGHT = 50;

	private const float MIN_MOUSE_SENSITIVITY = 1f;
	private const float MAX_MOUSE_SENSITIVITY = 10f;
	
	private float _mouseSensitivity = 2f;
	
	private GUIStyle _style;

	private GameObject menuUI;

	public void init(GUIStyle style) {
		_style = style;
		menuUI = GameObject.Find ("menuUI");
//		menuUI.renderer.enabled = false;
		menuUI.SetActive (false);
	}

	public void show(bool enable) {
//		menuUI.renderer.enabled = enable;
		Debug.Log ("Menu/show, enable = " + enable);
		isShowing = enable;
		menuUI.SetActive (enable);
	}
		
}
