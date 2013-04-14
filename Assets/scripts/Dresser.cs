using UnityEngine;
using System.Collections;

public class Dresser : MonoBehaviour {
	
	int openDrawer = -1;
	string[] drawerOpenClips = {
		"top_left_drawer_open",
		"top_center_drawer_open",
		"top_right_drawer_open",
		"middle_drawer_open",
		"bottom_drawer_open"
	};
	
	string[] drawerCloseClips = {
		"top_left_drawer_close",
		"top_center_drawer_close",
		"top_right_drawer_close",
		"middle_drawer_close",
		"bottom_drawer_close"
	};
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OpenDrawer(int clipIdx) {
		Debug.Log("OpenDrawer, idx = " + clipIdx + ", openDrawer = " + openDrawer);
		if(openDrawer > -1) {
			CloseDrawer(openDrawer);
		}
		PlayDrawerAnimation(drawerOpenClips[clipIdx]);		
		openDrawer = clipIdx;
	}
	
	public void CloseDrawer(int clipIdx) {
		Debug.Log("CloseDrawer, idx = " + clipIdx);
		PlayDrawerAnimation(drawerCloseClips[clipIdx]);
		openDrawer = -1;
	}
	
	void PlayDrawerAnimation(string clipName) {
		this.transform.animation.Play(clipName);	
	}
}
