using UnityEngine;
using System.Collections;

public abstract class OpenCloseParent : MonoBehaviour {
	public OpenCloseChild openChild;
	public abstract void ChildOpen(OpenCloseChild child);
	public abstract void ChildClose(OpenCloseChild child);
}