using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEPS : MonoBehaviour {

	public bool BuildColliding;

	void OnTriggerEnter (Collider other) {

		Debug.Log("SEX");
		if (other.tag == "Building")
		{
			BuildColliding = true;
		}

		else if (other.tag == "Terrain") {
			Debug.Log("GROUND");
		}

	}

	void OnTriggerExit () {
		
		BuildColliding = false;
	}
}
