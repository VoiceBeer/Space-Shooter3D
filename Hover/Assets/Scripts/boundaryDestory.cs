using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundaryDestory : MonoBehaviour {
	void OnTriggerExit(Collider other){
		if (other.tag == "Wall") {
			return;
		}
		Destroy (other.gameObject);
	}
}
