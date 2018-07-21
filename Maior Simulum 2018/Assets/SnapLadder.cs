using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapLadder : MonoBehaviour {

	public bool isSnapped = false;
	public bool LadderPlaced = false;
	public Animation Anim;
	void Start () {

		Anim = GetComponent<Animation>();

	}
	
	void Update () {
		
		if (LadderPlaced == true)
		{

			Anim.Play("PawnEscapesWell");			

		}

	}

	void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.tag == "TOP" && !isSnapped)
		{
			Debug.Log("SWITCH");
			other.gameObject.transform.position = new Vector3(this.transform.position.x, 0, this.transform.position.z);
		}
		
		if (other.gameObject.name == "Short Ladder")
		{
			Debug.Log("PLACED");

			isSnapped = true;
			LadderPlaced = true;

		}

	}
}
