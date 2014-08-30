using UnityEngine;
using System.Collections;

public class VRGUITest : VRGUI {

	public override void OnVRGUI() {
		GUILayout.BeginArea(new Rect(0f, 0f, Screen.width, Screen.height));
		if (GUILayout.Button("Click Me!"))
		{
			Debug.Log("button clicked");
		}
		GUILayout.EndArea();
	}
}
