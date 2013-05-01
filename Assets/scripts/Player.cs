using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var fpc = this.GetComponent<CharacterController>();
		Debug.Log("fpc = " + fpc);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
