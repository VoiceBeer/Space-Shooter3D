using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour {
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;
	private float turnSpeed = 1;
	public GameObject tower;

	// Update is called once per frame
	void Update () {
		tower.transform.Rotate (new Vector3 (0.0f, turnSpeed, 0.0f)); 
		shotSpawn.transform.Rotate (new Vector3 (0.0f, turnSpeed, 0.0f)); 

		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		}
	}
}
