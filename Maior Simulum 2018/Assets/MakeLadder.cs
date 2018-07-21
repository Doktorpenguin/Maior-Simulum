using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeLadder : MonoBehaviour {

	public bool LadderPlaced = false;
	public PlayerBuilding PB;
	public Animation Anim;
	void Start () {

		Anim = GetComponent<Animation>();
		PB = GameObject.Find("Player").GetComponent<PlayerBuilding>();

	}
	
	void Update () {
		
		if (LadderPlaced == true)
		{

			Anim.Play("PawnEscapeWell");			

		}

	}

	void OnTriggerEnter(Collider other)
	{

		Debug.Log("Press E To Place" + " " + PB.BuildMenu[PB.SelectorSlot].name);

	}
}
