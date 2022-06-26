using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColdBarDepletion : MonoBehaviour {
	public Bar coldBar;
	public Transform player;
	public Transform playerSprite;
	public GameObject campFire;
	public float distance;
	public float farFireDepletionRate;
	public float nearFireDepletionRate;

	private void Awake() {
		farFireDepletionRate = coldBar.depletionRate;
		nearFireDepletionRate = coldBar.depletionRate * 0.3f;
	}

	void Update() {
		distance = Vector2.Distance(player.position, campFire.transform.position);
		if (distance < 1.5 && campFire.activeSelf) {
			coldBar.depletionRate = nearFireDepletionRate;
		} else {
			coldBar.depletionRate = farFireDepletionRate;
		}
		if (coldBar.amount/100 < 0.25 && GameManager.timePassed > 3) {
			player.GetComponent<PlayerMovement_TopDown>().isMoveable = false;
			playerSprite.rotation = Quaternion.Euler(0, 0, 90);
		} else if (coldBar.amount / 100 > 0.28 && GameManager.timePassed > 3) {			
			playerSprite.rotation = Quaternion.Euler(0, 0, 0);
			player.GetComponent<PlayerMovement_TopDown>().isMoveable = true;
		}
	}
}
