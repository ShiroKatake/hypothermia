using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other) {
		if (GameManager.logCount < 2 && other.gameObject.layer == 9) {
			GameManager.logCount++;
			Destroy(gameObject);
		}
	}
}
