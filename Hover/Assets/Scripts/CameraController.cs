using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	
	public GameObject player;

	private float rotationDamping = 5;
	private float distance = 30;
	private float height = 8;

	void FixedUpdate () {
		// Calculate the wanted and current rotation angle
		float wantedRotationAngle = player.transform.eulerAngles.y; 
		float currentRotationAngle = transform.eulerAngles.y;

		// Damp the rotation around the Y-axis
		currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

		// Convert the angle into a quaternion
		Quaternion currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);

		// Set the (x,z) camera position based on where the player is
		transform.position = player.transform.position;
		transform.position -= currentRotation * Vector3.forward * distance;

		// Set the height (y) of the camera
		Vector3 newPosition = new Vector3 (transform.position.x, height, transform.position.z); transform.position = newPosition;

		// Look at the player
		transform.LookAt (player.transform);
	}
}
