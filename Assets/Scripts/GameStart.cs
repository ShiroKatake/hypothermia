using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour {
	public GameObject gameElements;

	void Start() {
		gameElements.SetActive(false);
	}

	public void GameStarting() {
		gameElements.SetActive(true);
		GameManager.gameStarted = true;
	}
}
