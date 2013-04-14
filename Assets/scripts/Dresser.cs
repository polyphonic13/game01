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
		if(openDrawer > -1) {
			PlayDrawerAnimation(drawerCloseClips[openDrawer]);
		}
		PlayDrawerAnimation(drawerOpenClips[clipIdx]);		
		openDrawer = clipIdx;
	}
	
	public void CloseDrawer(int clipIdx) {
		PlayDrawerAnimation(drawerCloseClips[clipIdx]);
		if(openDrawer > -1) {
			openDrawer = -1;
		}
	}
	
	void PlayDrawerAnimation(string clipName) {
		this.transform.animation.Play(clipName);	
	}
}
