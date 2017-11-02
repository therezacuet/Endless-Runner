using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoweUpManager : MonoBehaviour {


	private bool doublepoints;
	private bool safeMode;

	private bool powerUpActive;

	private float powerupLengthCounter;

	private ScoreManager theScoreManager;
	private PlatformGenerator thePlatformGenerator;

	private float normalPointPerSecond;
	private float spikeRate;

	private PlatformDestroy[] spikeList;

	private GameManager theGameManager;


	// Use this for initialization
	void Start () {

		theScoreManager = FindObjectOfType<ScoreManager> ();
		thePlatformGenerator = FindObjectOfType<PlatformGenerator> ();
		theGameManager = FindObjectOfType<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (powerUpActive) {

			powerupLengthCounter -= Time.deltaTime;

			if (theGameManager.powerUpReset) {

				powerupLengthCounter = 0;
				theGameManager.powerUpReset = false;
			}

			if(doublepoints){

				theScoreManager.pointsPerSecond = normalPointPerSecond * 2.75f;
				theScoreManager.shouldDouble = true;

			}

			if (safeMode) {

				thePlatformGenerator.randomSpikeThreshold = 0f;
			}

			if (powerupLengthCounter <= 0) {

				theScoreManager.pointsPerSecond = normalPointPerSecond;
				theScoreManager.shouldDouble = false;

				thePlatformGenerator.randomSpikeThreshold = spikeRate;
				powerUpActive = false;
			}
		}
	}

	public void ActivatePowerUp(bool points, bool safe, float time){

		doublepoints = points;
		safeMode = safe;
		powerupLengthCounter = time;

		normalPointPerSecond = theScoreManager.pointsPerSecond;
		spikeRate = thePlatformGenerator.randomSpikeThreshold;

		if (safeMode) {

			spikeList = FindObjectsOfType<PlatformDestroy>();
			for (int i = 0; i < spikeList.Length; i++) {

				if (spikeList [i].gameObject.name.Contains("spikes")) {

					spikeList [i].gameObject.SetActive (false);
				}
					
			}

		}

		powerUpActive = true;
	}
}
