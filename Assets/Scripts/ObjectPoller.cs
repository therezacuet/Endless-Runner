using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoller : MonoBehaviour {


	public GameObject pooledObject;

	public int pooledAmount;

	List <GameObject> pooledObjectList;


	// Use this for initialization
	void Start () {

		pooledObjectList = new List<GameObject>();

		for(int i=0; i< pooledAmount; i++){

			GameObject obj = (GameObject) Instantiate (pooledObject);
			obj.SetActive(false);
			pooledObjectList.Add(obj);
		}
		
	}
	
	public GameObject GetPooledObject(){

		for(int i=0; i< pooledObjectList.Count; i++){

			if(!pooledObjectList[i].activeInHierarchy ){

				return pooledObjectList[i];
			}
		}

			GameObject obj = (GameObject) Instantiate (pooledObject);
			obj.SetActive(false);
			pooledObjectList.Add(obj);
			return obj;
	}
	
}
