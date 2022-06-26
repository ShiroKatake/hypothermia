using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour {
	public Animator animator;
	public TextMeshProUGUI dialogueText;
	public Bar coldBar;
	public Bar fireBar;
	public PlayerMovement_TopDown playerMovement;
	public static bool isInDialogue;
	private Queue<string> sentences;

	void Start() {
		sentences = new Queue<string>();
	}

	private void Update() {
		if (Input.GetButtonDown("Talk")) {
			DisplayNextSentence();
		}
		if (isInDialogue) {
			coldBar.amount += coldBar.depletionRate * Time.deltaTime;
			fireBar.amount += fireBar.depletionRate * Time.deltaTime;
		}
	}
	public void StartDialogue(Dialogue dialogue) {
		playerMovement.enabled = false;
		isInDialogue = true;
		animator.SetBool("isOpen", true);
		sentences.Clear();
		foreach (string sentence in dialogue.sentences) {
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence() {
		if (sentences.Count == 0) {
			EndDialogue();
			return;
		}
		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence(string sentence) {
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray()) {
			dialogueText.text += letter;
			for (int i = 0; i < 3; i++) {
				yield return null;
			}
		}
	}

	public void EndDialogue() {
		isInDialogue = false;
		playerMovement.enabled = true;
		animator.SetBool("isOpen", false);
	}
}
