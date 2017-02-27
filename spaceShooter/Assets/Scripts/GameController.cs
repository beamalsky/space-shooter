using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	
	public GameObject hazard;
	public GameObject hazard1;
	public GameObject hazard2;
	private GameObject[] hazards;

	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	//build array, begin coroutine
	void Start () {
		hazards = new GameObject[3];
		hazards [0] = hazard;
		hazards [1] = hazard1;
		hazards [2] = hazard2;
		StartCoroutine (SpawnWaves ());
	}

	//pick a random gameobject from an array
	GameObject SpawnAsteroid (GameObject[] h) {
		int randomIndex = Random.Range(0, hazards.Length);
		return h[randomIndex];
	}

	IEnumerator SpawnWaves () {
		yield return new WaitForSeconds (startWait);

		while (true) {
			for (int i = 0; i < hazardCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (SpawnAsteroid(hazards), spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}
}