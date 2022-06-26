using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour {
	public Image barImage;
	const int maxAmount = 100;
	public float amount;
	public float depletionRate = 10;
	public Animator animator;

	void Awake() {
		amount = maxAmount;
	}

	void Update() {
		amount -= depletionRate * Time.deltaTime;
		amount = Mathf.Clamp(amount, 0f, maxAmount);
		barImage.fillAmount = GetAmountNormallized();
	}

	public void TryRefill(float amountRefill) {
		amount += amountRefill;
	}

	public float GetAmountNormallized() {
		return amount / maxAmount;
	}

	public void AnimatorDisable() {
		animator.enabled = false;
	}
}
