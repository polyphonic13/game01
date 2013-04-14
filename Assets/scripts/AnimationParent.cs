using UnityEngine;
using System.Collections;

public abstract class AnimationParent : MonoBehaviour {
	public abstract void ChildOpen(int idx);
	public abstract void ChildClose(int idx);
}