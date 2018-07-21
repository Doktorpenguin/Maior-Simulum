using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Houses : MonoBehaviour {

	public Builder HouseType;
	public int Health;
	void Start () {

		Health = HouseType.Health;

	}
	
	void Update () {

		if (Health <= 0)
		{
			Destroy(this.gameObject);
		}

		if (Input.GetKeyDown(KeyCode.F))
		{

			Punch(1);

		}

	}

	public void Punch(int Damage)
	{

		Health -= Damage;

	}
}
