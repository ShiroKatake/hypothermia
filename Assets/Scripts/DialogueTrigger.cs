using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {
	public Dialogue dialogue;
	public float triggerTime;

	public void TriggerDialogue() {
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
	}
	
	void Update() {
		if (GameManager.timePassed >= triggerTime && GameManager.timePassed < triggerTime + 0.1) {
			TriggerDialogue();
		}
	}
}
