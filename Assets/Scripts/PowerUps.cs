using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour {

	public bool doublepoints;
	public bool safeMode;

	public float powerUpLength;

	private PoweUpManager thePowerupManager;

	public Sprite[] powerUpSprite;

	// Use this for initialization
	void Start () {

		thePowerupManager = FindObjectOfType<PoweUpManager> ();
	}


	void Awake(){

		int powerSelector = Random.Range (0, 2);

		switch (powerSelector) {
			
		case 0:
			doublepoints = true;
			break;
		case 1:
			safeMode = true;
			break;
		
		}

		GetComponent<SpriteRenderer> ().sprite = powerUpSprite [powerSelector];

	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.name == "Player") {

			thePowerupManager.ActivatePowerUp (doublepoints, safeMode, powerUpLength);
		}

		gameObject.SetActive (false);
	}
}
