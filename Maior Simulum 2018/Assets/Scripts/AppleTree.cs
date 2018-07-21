using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : TreeScript {

	void Start () {
		
		Health = 10;

	}
	
	void Update () {
		
		if (Health <= 0 && Dead == false)
		{

			Death();

		}


	}

	override public void Death ()
	{

		base.Death();


	}

	public override void Punch (int attack)
	{	
		//If the tree isn't dead then do the following.
		if (!Dead)
		{
			//Health depleted based on the player's Attack stat.
			Health += -attack;
			//Animation is played to show the player the tree was hit.
			Anim.Play("AppleTreeWiggle");
			//The wood the player receives after hitting the tree
			IC.woodRSC += Random.Range(3,5);
		}

	}
}
