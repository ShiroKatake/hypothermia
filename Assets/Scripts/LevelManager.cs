using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	static LevelManager instance;
	void Awake() {
		if (instance != null) {
			Destroy(gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

	public void LoadScene(int scene) {
		SceneManager.LoadScene(scene);
	}

	public void Quit() {
		Application.Quit();
	}
}
