using UnityEngine;
using System.Collections;

public class Dresser : AnimationParent {
	
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
	
	public override void ChildOpen(int clipIdx) {
		//Debug.Log("OpenDrawer, idx = " + clipIdx + ", openDrawer = " + openDrawer);
		if(openDrawer > -1) {
			ChildClose(openDrawer);
		}
		PlayDrawerAnimation(drawerOpenClips[clipIdx]);		
		openDrawer = clipIdx;
	}
	
	public override void ChildClose(int clipIdx) {
		//Debug.Log("CloseDrawer, idx = " + clipIdx);
		PlayDrawerAnimation(drawerCloseClips[clipIdx]);
		openDrawer = -1;
	}
	
	private void PlayDrawerAnimation(string clipName) {
		this.transform.animation.Play(clipName);	
	}
}
