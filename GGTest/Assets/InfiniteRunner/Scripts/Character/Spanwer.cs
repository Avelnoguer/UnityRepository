using UnityEngine;
using System.Collections;

public class Spanwer : MonoBehaviour {

	public GameObject [] gameObjectsToSpawn;
	public float spawnSpeed = 2f;
	public float spawnX = 7.5f;

	private float maxUpperMovement = 0.4f;
	private float maxBottomMovement = -3f;
	private float nextSpawn = 0;

	private int arrayMaxSize = 0;

	private void Start(){

		this.arrayMaxSize = gameObjectsToSpawn.Length;
	
	}

	private void Update(){
		GameObjectSelector ();
	}


	private void GameObjectSelector(){

		if (Time.time > nextSpawn) {
			int index = Random.Range (0, arrayMaxSize);
			float randomY = Random.Range (maxBottomMovement, maxUpperMovement);
			Instantiate (gameObjectsToSpawn [index], new Vector3 (spawnX, randomY, 0f), Quaternion.identity);
			//mo.transform.position = new Vector3 (spawnX, randomY, 0f);
			nextSpawn =  Time.time + this.spawnSpeed;
		}
	}


}
