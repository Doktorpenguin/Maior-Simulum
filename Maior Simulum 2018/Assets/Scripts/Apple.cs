using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour {

	public AppleTree AT;
	public Rigidbody rb;


	void Start () {

		rb = GetComponent<Rigidbody>();
		AT = GetComponentInParent<AppleTree>();
		rb.constraints = RigidbodyConstraints.FreezeAll;

	}
	
	void Update () {
		
		if (AT.Dead)
		{
			Drop();
		}

	}

	public void Drop ()
	{
		
		rb.constraints = RigidbodyConstraints.None;

	}
}
