using UnityEngine;
using System.Collections;

public class Menu {

	public bool showMenu { get; set; }
	
	public void draw() {
		drawBackground("Menu");
	}

	public void drawBackground(string title) {
		GUI.Box(new Rect(5, 5, Screen.width - 10, Screen.height - 10), title /*, _style */);
	}
	
}
