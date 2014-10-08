using UnityEngine;
using System.Collections;

public class Utils : MonoBehaviour
{

	private static Utils _instance;
	private Utils() {}

	public static Utils Instance {
		get {
			if(_instance == null) {
				_instance = new Utils();
			}
			return _instance;
		}
	}

	public void showHideChildren(GameObject pops, bool show) {
		// set the parents renderer to value passed, if not already done
		if(pops.renderer.enabled != show) {
			pops.renderer.enabled = show;
		}
		// get all child renderers and set their enabled
		Renderer[] renderers = pops.GetComponentsInChildren<Renderer>();
		if(renderers != null) {
			foreach(Renderer r in renderers) {
				r.enabled = show;
			}
		}
	}

	public void reorder() {
		/*
		int[] numbers = { 1, 3, 4, 9, 2, 4 };
		int numToRemove = 4;
		int numIdx = Array.IndexOf(numbers, numToRemove);
		List<int> tmp = new List<int>(numbers);
		tmp.RemoveAt(numIdx);
		numbers = tmp.ToArray();
		*/
	}
}

