using UnityEngine;
using System.Collections;

public class MouseTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log ("mouse test start");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnMouseDown() {
				Debug.Log ("mouse test on mouse down");
		}

	public void OnMouseOver() {
				Debug.Log ("mouse test on mouse over");
		}
}
