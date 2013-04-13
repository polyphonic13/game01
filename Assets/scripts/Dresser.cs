using UnityEngine;
using System.Collections;

public class Dresser : MonoBehaviour {
	
	int drawerState = 0;
	string[] drawerStates = {
		"top_left_drawer_open",
		"top_left_drawer_close",
		"top_center_drawer_open",
		"top_center_drawer_close",
		"top_right_drawer_open",
		"top_right_drawer_close",
		"middle_drawer_open",
		"middle_drawer_close",
		"bottom_drawer_open",
		"bottom_drawer_close"
	};
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnMouseDown() {
		Debug.Log("dresswer on mouse down, drawerState = " + drawerState + ", animation = " + transform.animation.GetClip(drawerStates[drawerState]));
		transform.animation.Play(drawerStates[drawerState]);
		if(drawerState < drawerStates.Length - 1) {
			drawerState++;
		} else {
			drawerState = 0;
		}
	}
}
