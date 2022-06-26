using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBarRefill : MonoBehaviour {
	public Bar fireBar;
	public int refillRate = 7;

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.layer == 9 && GameManager.logCount > 0) {
			fireBar.TryRefill(refillRate * GameManager.logCount);
			GameManager.logCount = 0;
		}
	}
}
