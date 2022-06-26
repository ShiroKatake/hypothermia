using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class DistanceMeasure : MonoBehaviour {
	public float distance;
	public Transform target;
	void Update() {
		distance = Vector2.Distance(transform.position, target.position);
	}
}
