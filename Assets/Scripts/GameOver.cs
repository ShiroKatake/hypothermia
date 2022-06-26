using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour {
	public TextMeshProUGUI gameOverText;
	public GameObject continueButton;
	private string sentence;

	private void Start() {
		sentence = gameOverText.text;
		continueButton.SetActive(false);
	}

	public void StartGameOver() {
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence(string sentence) {
		gameOverText.text = "";
		foreach (char letter in sentence.ToCharArray()) {
			gameOverText.text += letter;
			for (int i = 0; i < 3; i++) {
				yield return null;
			}
		}
		continueButton.SetActive(true);
	}
}
