using UnityEngine;
using System.Collections;

public abstract class AnimationParent : MonoBehaviour {
	public string openChildName;
	//public int openChildIdx;
	//public abstract void ChildOpen(int idx);
	//public abstract void ChildClose(int idx);
	public abstract void ChildOpen(string clip, string childName);
	public abstract void ChildClose(string clip, string childName);
}