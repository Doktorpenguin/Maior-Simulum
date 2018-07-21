using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour {

	public Rigidbody rb;


	void Start () {

		rb = GetComponent<Rigidbody>();
		rb.constraints = RigidbodyConstraints.FreezeAll;

	}
	
	void Update () {
		
		

	}

	public void Drop ()
	{
		
		rb.constraints = RigidbodyConstraints.None;

	}
}
