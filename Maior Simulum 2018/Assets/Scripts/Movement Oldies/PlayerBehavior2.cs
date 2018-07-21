using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior2 : MonoBehaviour {

	public enum State {State_Idle, State_Jumping}
	public State state_;
	public bool Grounded;
	private Rigidbody rb;
	void Start () {
		rb = GetComponent<Rigidbody>();
		Cursor.lockState = CursorLockMode.Locked;
		state_ = State.State_Idle;

	}
	
	void Update () {
		
		switch (state_)
		{
			case State.State_Idle:
			if	(Input.GetButtonDown ("Jump")) 
			{
				state_ = State.State_Jumping;
				rb.velocity = Vector3.up * 7;
				Grounded = false;
			}
			break;

			case State.State_Jumping:
			if (Grounded)
			{
				state_ = State.State_Idle;
			}

			//Movement State Code

			break;

			default:
			state_ = State.State_Idle;
			Debug.Log("BANANA");
			break;
			
		}

	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "Terrain")
		{
			Grounded = true;
		}
	}

	void OnCollisionExit (Collision col)
	{
		Grounded = false;
	}
}
