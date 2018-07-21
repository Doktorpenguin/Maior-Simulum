using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {

	public bool inside = false;
	public Animation Anim;
	void Start () {

		Anim = GameObject.Find("Pawn").GetComponent<Animation>();
		Anim.Play("PawnEscapesWell");

	}
	
	void Update () {
		
		if (Input.GetKey(KeyCode.T))
		{
			Anim.Play("PawnEscapesWell");
		}

	}

	void OnTriggerEnter (Collider other) {

		//other.transform.position += Vector3.up / heightFactor;
		Climb(other.gameObject, 2);
		//Debug.Log("EX");

	}

	void OnTriggerExit (Collider other) {

		inside = false;
	}

	public void Climb (GameObject Thing, float height)
	{

		Thing.transform.position += Vector3.up / height;

	}
}
