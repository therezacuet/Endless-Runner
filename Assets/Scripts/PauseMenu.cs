using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public string mainMenuLevel;

	public GameObject pauseMenu;

	public GameObject PauseButton;

	public void PauseGame(){

		Time.timeScale = 0f;
		pauseMenu.SetActive (true);
		PauseButton.SetActive (false);


	}

	public void Resume(){

		Time.timeScale = 1f;
		pauseMenu.SetActive (false);
		PauseButton.SetActive (true);
	}

	public void Restart(){

		Time.timeScale = 1f;
		pauseMenu.SetActive (false);
		PauseButton.SetActive (true);
		FindObjectOfType<GameManager> ().Reset();
	}
	public void MainMenu(){

		Time.timeScale = 1f;
		Application.LoadLevel (mainMenuLevel);
	}
}
