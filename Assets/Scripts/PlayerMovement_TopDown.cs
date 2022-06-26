using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_TopDown : MonoBehaviour {
	public Animator animator;
	public float runSpeed = 20.0f;
	public Bar coldBar;
	public float refillRate;
	public float decreaseSpeed;
	public int gameLength = 195;

	private Rigidbody2D rb;
	private Vector2 moveVelocity;
	public bool isMoveable;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
	}

	void Update() {
		if (isMoveable) {
			if (GameManager.gameStarted && !DialogueManager.isInDialogue) {
				refillRate -= decreaseSpeed / gameLength * Time.deltaTime;
			}
			Vector2 movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
			animator.SetFloat("speed", Mathf.Abs(movementInput.magnitude));
			moveVelocity = movementInput * runSpeed;
			Vector3 characterScale = transform.localScale;
			if (Input.GetAxisRaw("Horizontal") < 0) {
				characterScale.x = 1;
			}
			if (Input.GetAxisRaw("Horizontal") > 0) {
				characterScale.x = -1;
			}
			transform.localScale = characterScale;

		}
		if (Input.GetButtonDown("Keep Warm")) {
			coldBar.TryRefill(refillRate);
		}
	}

	void FixedUpdate() {
		rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
	}
}
