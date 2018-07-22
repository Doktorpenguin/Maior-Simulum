using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour {

	public int Health;
	public bool Dead = false;
	public InventoryController IC;
	protected Animation Anim;
	virtual public void Start () {
		IC = GameObject.Find("Player").GetComponent<InventoryController>();
		Anim = GetComponent<Animation>();
		Health = 10;

	}
	
	void Update () {

		if (Health <= 0 && Dead == false)
		{

			Death();

		}

	}
	//When The Tree Dies It Rolls Over And Gives The Player Some Wood, 
	//Also Sets "TreeDead" To Equal True Telling The Script To Stop Treating It Like It's Alive (eg. Don't Play Animations)
	virtual public void Death ()
	{
		Dead = true;
		transform.Rotate(-90, 0, 0);
		transform.Translate(0, -1, 0);
		//woodRSC += Random.Range(3,12);
		//IC.woodRSC += Random.Range(5,15);

	}

	//What happens when the player punches this tree.
	virtual public void Punch (int attack)
	{	
		//If the tree isn't dead then do the following.
		if (!Dead)
		{
			//Health depleted based on the player's Attack stat.
			Health += -attack;
			//Animation is played to show the player the tree was hit.
			Anim.Play("TreeWiggle");
			//The wood the player receives after hitting the tree
			IC.woodRSC += Random.Range(3,5);
		}

	}

}
