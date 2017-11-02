using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {


	public GameObject thePlatform;
	public Transform generationPoint;
	public float distanceBetween;

	private float platformWidth;

	public float distanceBetweenMin;
	public  float distanceBetweenMax;

	private int platformSelector;

	private float[] platFormWidths;

	//public GameObject[] thePlatforms;

	public ObjectPoller[] theObjectPools;

	private float minHeight;
	public Transform maxHeightPoint;
	private float maxHeight;
	public float maxHeightChange;
	private float heightChange;

	private CoinGenerator theCoinGenerator;
	public float randomCoinThreshold;

	public float randomSpikeThreshold;
	public ObjectPoller spikePool;

	public float powerupHeight;
	public ObjectPoller powerupPool;
	public float powerupThreshold;



	// Use this for initialization
	void Start () {
		//platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;

		platFormWidths = new float[theObjectPools.Length];

		for(int i=0; i< theObjectPools.Length; i++){

			platFormWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
		}

		minHeight = transform.position.y;
		maxHeight = maxHeightPoint.position.y;

		theCoinGenerator = FindObjectOfType<CoinGenerator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if(transform.position.x < generationPoint.position.x){

			distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
			platformSelector = Random.Range(0,theObjectPools.Length);

			heightChange = transform.position.y + Random.Range (maxHeightChange, -maxHeightChange);

			if (heightChange > maxHeight || heightChange < minHeight) {

				heightChange = maxHeight;

			} else if (heightChange < minHeight) {
				
				heightChange = minHeight;
			}


			if (Random.Range(0f, 100f) < powerupThreshold) {

				GameObject newPowerUp = powerupPool.GetPooledObject ();

				newPowerUp.transform.position = transform.position + new Vector3 (distanceBetween/2f,Random.Range(powerupHeight/2f, powerupHeight), 0f);

				newPowerUp.SetActive (true);
			}


			transform.position = new Vector3(transform.position.x + (platFormWidths[platformSelector] / 2) + distanceBetween, heightChange, transform.position.z);

			//Instantiate (/*thePlatform*/thePlatforms[platformSelector], transform.position, transform.rotation);



			GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive(true);

			if (Random.Range (0f, 100f) < randomCoinThreshold) {

				theCoinGenerator.SpawnCoins (new Vector3(transform.position.x, transform.position.y+1f,transform.position.z));
			}
			if (Random.Range (0f, 100f) < randomSpikeThreshold) {

				GameObject newSpike = spikePool.GetPooledObject ();

				float spikeXposition = Random.Range (-platFormWidths[platformSelector]/2f + 1f, platFormWidths[platformSelector]/2f - 1f);

				Vector3 spikePosition = new Vector3 (spikeXposition, 0.5f, 0f);

				newSpike.transform.position = transform.position + spikePosition;
				newSpike.transform.rotation = transform.rotation;
				newSpike.SetActive (true);
			}



			transform.position = new Vector3(transform.position.x + (platFormWidths[platformSelector] / 2), transform.position.y, transform.position.z);



		}
		
	}
}
