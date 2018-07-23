using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : TreeScript {
	
	public Apple[] Apples;
	public Transform appleParent;

	override public void Start()
	{
		base.Start();
		Apples = appleParent.GetComponentsInChildren<Apple>();
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
		foreach (Apple item in Apples)
		{
			item.Drop();
		}


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
			//The wood the player receives after hitting the tree.
			IC.woodRSC += Random.Range(3,5);
			//Makes all the apples attached to the tree fall when its hit.
			foreach (Apple item in Apples)
			{
				var numb = Random.Range(0,5);
				Debug.Log(numb);
				if (numb == 0)
				{
					item.Drop();
				}

				else {}
			}
		}

	}
}
