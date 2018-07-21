using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildLadder : MonoBehaviour {

	private float Range = 4.5f;
	public PlayerBuilding PB;
	private InventoryController Ic;
	public Text TT;
	public Builder SL;
	public bool IsBuild = false;
	void Start () {
		PB = GameObject.Find("Player").GetComponent<PlayerBuilding>();
	}
	
	void Update () {

		if (Physics.Raycast(PB.ray, out PB.hit, Range))
		{

			if (PB.hit.collider.name == "SS Short Ladder TOP" && !IsBuild)
			{

				TT.text = "Press [E] To Build Short Ladder For 25 Wood";
				if (Input.GetKey(KeyCode.E))
				{
					//Make a Special Virtual Version of The "Build" Function.
					Build(SL);
				}

			}

		}

		else 
		{
			TT.text = " ";
		}

		if (IsBuild)
		{
			Destroy(this.gameObject);
		}
	}

	public void Build (Builder Blueprint)
	{
		if (PB.Ic.woodRSC >= Blueprint.Cost)
		{
			PB.Ic.woodRSC -= Blueprint.Cost;
			Instantiate(Blueprint.Prefab, this.transform.position, transform.rotation *  Quaternion.Euler(0, 0, 0));
			IsBuild = true;
		}

	}
}
