using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour {

	public string mainMenuLevel;

	public GameObject PauseButton;

	public void Restart(){

		FindObjectOfType<GameManager> ().Reset();
		PauseButton.SetActive (true);

	}
	public void MainMenu(){

		Application.LoadLevel (mainMenuLevel);
	}

}
