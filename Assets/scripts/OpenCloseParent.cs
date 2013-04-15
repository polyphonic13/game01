using UnityEngine;
using System.Collections;

public abstract class OpenCloseParent : MonoBehaviour {
	public OpenCloseChild currentOpen;
	public abstract void OpenChild(OpenCloseChild child);
	public abstract void CloseChild(OpenCloseChild child);
}