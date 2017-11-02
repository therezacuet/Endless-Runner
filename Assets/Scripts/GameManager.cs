using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


	public Transform platformGenerator;
	private Vector3 platformStartPoint;

	public PlayerControl thePlayer;
	private Vector3 thePlayerStartPoint;

	private PlatformDestroy[] platformList;

	private ScoreManager theScoreManager;

	public DeathMenu theDeathScreen;
	public GameObject PauseButton;

	public bool powerUpReset;

	// Use this for initialization
	void Start () {

		platformStartPoint = platformGenerator.position;
		thePlayerStartPoint = thePlayer.transform.position;

		theScoreManager = FindObjectOfType<ScoreManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RestartGame(){

		theScoreManager.scoreIncreasing = false;
		thePlayer.gameObject.SetActive (false);

		theDeathScreen.gameObject.SetActive (true);
		//StartCoroutine ("RestartGameCo");

		PauseButton.SetActive (false);

	}

	public void Reset(){
		theDeathScreen.gameObject.SetActive (false);

		platformList = FindObjectsOfType<PlatformDestroy>();
		for (int i = 0; i < platformList.Length; i++) {

			platformList [i].gameObject.SetActive (false);
		}

		thePlayer.transform.position = thePlayerStartPoint;
		platformGenerator.position = platformStartPoint;
		thePlayer.gameObject.SetActive (true);
		theScoreManager.scoreCount = 0;
		theScoreManager.scoreIncreasing = true;

		powerUpReset = true;
	}

	/*public IEnumerator RestartGameCo(){

		theScoreManager.scoreIncreasing = false;
		thePlayer.gameObject.SetActive (false);
		yield return new WaitForSeconds(0.5f);
		platformList = FindObjectsOfType<PlatformDestroy>();
		for (int i = 0; i < platformList.Length; i++) {

			platformList [i].gameObject.SetActive (false);
		}

		thePlayer.transform.position = thePlayerStartPoint;
		platformGenerator.position = platformStartPoint;
		thePlayer.gameObject.SetActive (true);
		theScoreManager.scoreCount = 0;
		theScoreManager.scoreIncreasing = true;
	}*/
}
