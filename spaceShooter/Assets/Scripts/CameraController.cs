using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;
	public Boundary boundary;

	private Vector3 offset;

	void Start() {
		offset = transform.position - player.transform.position;
	}

	void LateUpdate () {

		if (player != null) {
			transform.position = player.transform.position + offset;

			transform.position = new Vector3 (
				Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax), 
				10.0f, 
				Mathf.Clamp(transform.position.z, boundary.zMin, boundary.zMax)
			);
		}
	}

}
