using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	public string PlayGameLevel;

	public void PlayGame(){
		Application.LoadLevel (PlayGameLevel);

	}
	public void QuitGame(){

		Application.Quit ();
	}
}
