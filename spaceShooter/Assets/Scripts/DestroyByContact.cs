using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;

	private Transform tf;

	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		} else {
			Debug.Log ("oops can't find a game controller");
		}
	}

	void OnTriggerEnter (Collider other) {
		tf = GetComponent<Transform> ();

		if ((other.tag == "Boundary") || (other.tag == "Enemy") ) {
			return;
		} else {
			Instantiate (explosion, tf.position, tf.rotation);
			if (other.tag == "Player") {
				Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
				gameController.GameOver ();
			}
				
			gameController.AddScore (scoreValue);
			Destroy (gameObject);
			Destroy (other.gameObject);
		}
	}
		
}