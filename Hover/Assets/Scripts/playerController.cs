using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
	
	private float speed = 20;
	private float turnSpeed = 3;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;
	private int health = 10;
	public GameObject explosion;
	public GameObject bigexplosion;
	private GameController controller;

	// Use this for initialization
	void Start () {
		GameObject tmp = GameObject.FindGameObjectWithTag ("GameController");
		controller = tmp.GetComponent<GameController> ();
		if (controller == null) {
			Debug.LogError ("Unable to find the GameController Script");
		}

	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		// Turning
		if(moveHorizontal != 0) {
			transform.Rotate (new Vector3 (0.0f, moveHorizontal * turnSpeed, 0.0f)); }

		// Forward or backwards
		if (moveVertical != 0) {
			Vector3 fwd = transform.forward;
			GetComponent<Rigidbody> ().velocity = fwd * speed * moveVertical; }
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKey("space") && Time.time>nextFire){
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		}else if(Input.GetButton("Fire1") && Time.time>nextFire){
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		}
		
	}

	void OnTriggerEnter(Collider other){
		switch (other.tag) {
		case "boundary":
			return;
		case "enemybullet":
			if (health > 0) {
				Instantiate (explosion, transform.position, transform.rotation);
				Destroy (other.gameObject);
				health--;
				controller.MinusHP (10);
			}
			break;
		case "enemy":
			if (health > 0) {
				Instantiate (bigexplosion, transform.position, transform.rotation);
				Destroy (other.gameObject);
				if ((health - 2) >= 0) {
					health -= 2;
					controller.MinusHP (20);
				} else {
					health -= 1;
					controller.MinusHP (10);
				}
			}
			break;
		default:
			return;
		}

		if( health <1){
			Instantiate (bigexplosion, transform.position, transform.rotation);
			Destroy (other.gameObject);
			Destroy (gameObject);
			controller.EndGame();
		}
		
	}

}
