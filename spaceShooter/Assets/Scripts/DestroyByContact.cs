using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	private Transform tf;

	void OnTriggerEnter (Collider other) {
		tf = GetComponent<Transform> ();

		if (other.tag == "Boundary") {
			return;
		} else {
			Instantiate (explosion, tf.position, tf.rotation);
			if (other.tag == "Player") {
				Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			}
			Destroy (gameObject);
			Destroy (other.gameObject);
		}
	}
}