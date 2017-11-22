using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDestory : MonoBehaviour {
	public GameObject explosion;
	private GameController controller;

	void Start () {
		GameObject tmp = GameObject.FindGameObjectWithTag ("GameController");
		controller = tmp.GetComponent<GameController> ();
		if(controller == null) {
			Debug.LogError("Unable to find the ContactDestroy script");
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "boundary"||other.tag =="enemybullet") {
			
			return;
		}

		if (other.tag == "Player"){
			controller.AddScore (10);
			return;
		}

		Destroy (other.gameObject);
		Destroy (gameObject);
		Instantiate (explosion, transform.position, transform.rotation);

		controller.AddScore (10);
	}
}
