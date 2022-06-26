using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour {
	public TextMeshProUGUI logCountText;
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		logCountText.text = "x" + GameManager.logCount.ToString();
	}
}
