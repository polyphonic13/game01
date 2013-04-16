using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class OpenCloseChild : MonoBehaviour {
	public OpenCloseParent parent;
	public string openClipName;
	public string closeClipName;
	public bool isOpen;
}
