using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {

	public class CharacterState
	{
		public virtual void Update() {}

	}

	public enum State {State_Idle, State_Jumping}
	public State state_;
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		//state_ = State.State_Idle;

	}
	
	public virtual void Update () {
		
		switch (state_)
		{

			default:
			state_ = State.State_Idle;
			Debug.Log("BANANA");
			break;
			
		}

	}
}
