using UnityEngine;
using System.Collections;

public abstract class OpenCloseChild : MonoBehaviour {
	public OpenCloseParent parent;
	public string openClipName;
	public string closeClipName;
	public bool isOpen;
}
