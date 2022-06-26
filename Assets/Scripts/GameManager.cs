using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public static int logCount = 0;
	public TextMeshProUGUI logCountText;
	public Bar coldBar;
	public Bar fireBar;
	public GameObject campFire;
	public static float timePassed;
	public Animator animator;
	public Animator gameOverAnimator;
	public static bool gameStarted;
	public PlayerMovement_TopDown playerMovement;
	public float fadeInAlpha = 240;
	public Image hypothermia;

	void Start() {
		campFire.SetActive(true);
	}

	void Update() {
		Color tempColor = hypothermia.color;
		if (!gameStarted) {
			timePassed = 0;
			playerMovement.enabled = false;
		}
		if (gameStarted && !DialogueManager.isInDialogue) {
			playerMovement.enabled = true;
		}
		timePassed += Time.deltaTime;
		logCountText.text = "x" + logCount.ToString();
		if (coldBar.amount <= 0) {
			playerMovement.enabled = false;
			tempColor.a = 1;
			hypothermia.color = tempColor;
			gameOverAnimator.SetBool("isGameOver", true);
			Debug.Log("Game Over. Time taken: " + timePassed);
		}
		if (fireBar.amount <= 0) {
			campFire.SetActive(false);
		} else {
			campFire.SetActive(true);
		}
		tempColor.a = 1 - coldBar.amount / 100;
		hypothermia.color = tempColor;
	}

	public void StartClicked() {
		animator.SetBool("isStarting", true);
	}
}
