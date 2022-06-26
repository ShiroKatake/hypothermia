using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SnapToGrid : MonoBehaviour {
	public float gridSize = 0.5f;
	float x, y;
	
	void Update() {
		if (gridSize > 0) {
			float reciprocalGrid = 1f / gridSize;

			x = Mathf.Round(transform.position.x * reciprocalGrid) / reciprocalGrid;
			y = Mathf.Round(transform.position.y * reciprocalGrid) / reciprocalGrid;

			transform.position = new Vector3(x, y, transform.position.z);

		}
	}
}
