using UnityEngine;
using System.Collections;

public class InvertedCamera : MonoBehaviour {
	public int forward = 1;
	public int up = 1;
	public int right = 1;

	// EXAMPLE WITH CAMERA UPSIDEDOWN
	void OnPreCull () {
		camera.ResetWorldToCameraMatrix();
		camera.ResetProjectionMatrix();
		camera.projectionMatrix = camera.projectionMatrix * Matrix4x4.Scale(new Vector3(forward, up, right));
	}
	
	void OnPreRender () {
		GL.SetRevertBackfacing(true);
	}
	
	void OnPostRender () {
		GL.SetRevertBackfacing(false);
	}
	
}
