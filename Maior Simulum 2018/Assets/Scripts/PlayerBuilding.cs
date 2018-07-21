using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuilding : MonoBehaviour {
	//Setting Up Variables...
	private GameObject Player;
	private GameObject TP;
	public GameObject Selector;
	public InventoryController Ic;
	public bool HouseBuildON;
	public int SelectorSlot;
	public Ray ray;
	public RaycastHit hit;

	public Builder[] BuildMenu;
	//Avoid Buildings being placed inside eachother
	Camera cam;
	void Start () {
		//Component Setups...
		cam = GetComponentInChildren<Camera>();
		Player = GameObject.Find("Player");
		Ic = Player.GetComponent<InventoryController>();

	}
	
	public void Update () {

		#region Controls
		//Ray Setup
		ray = cam.ScreenPointToRay(Input.mousePosition);
		//Everything that requires aiming...
		if (Physics.Raycast(ray, out hit))
		{
			if (TP != null)
			{
				//Building moves with the player mouse
				TP.transform.position = new Vector3(hit.point.x, 0, hit.point.z);
			}
			
		}

		//When First Pressed The Code Will Spawn The TOP(Transparent. Object. Preview) Of Their Desired Building Allowing To Choose The Building's Location.
		if (Input.GetKeyDown(KeyCode.H))
		{
			if (HouseBuildON == false)
			{
				HouseBuildON = true;
				TP = Instantiate(BuildMenu[SelectorSlot].TOP, hit.point, Quaternion.identity);
			}

			else if (HouseBuildON == true)
			{
				HouseBuildON = false;
				Destroy(TP);
			}

		}

		//When Player Presses 1 The Selector Moves Left
		if (Input.GetKeyDown(KeyCode.Alpha1) && Selector.transform.position.x > 917 && HouseBuildON == true)
		{
			Selector.transform.Translate(-130, 0, 0);
			SelectorSlot -= 1;
			Destroy(TP);
			TP = Instantiate(BuildMenu[SelectorSlot].TOP, hit.point, Quaternion.identity);
		}

		//When Player Presses 2 The Selector Moves Right
		if (Input.GetKeyDown(KeyCode.Alpha2) && Selector.transform.position.x < 1177 && HouseBuildON == true)
		{
			Selector.transform.Translate(130, 0, 0);
			SelectorSlot += 1;
			Destroy(TP);
			TP = Instantiate(BuildMenu[SelectorSlot].TOP, hit.point, Quaternion.identity);
		}

		if (Input.GetMouseButton(0) && HouseBuildON == true)
		{

			Build(BuildMenu[SelectorSlot]);

		}
		#endregion

	}
	
	//This function checks if you have enough resources to in your inventory before spawning the building
	public void Build (Builder Blueprint) {

		//Get The Script from the TOP
		TEPS PT = TP.GetComponent<TEPS>();

		//Add Particles On Spawn
			if (Blueprint.resourceCostType == 0)
		{

			if (Ic.woodRSC >= Blueprint.Cost)
			{	
				//Checks if the TOP is colliding with a building
				if (PT.BuildColliding == false)
				{

					Ic.woodRSC -= Blueprint.Cost;
					//Store Below In variable
					GameObject ShackB = Instantiate(Blueprint.Prefab, TP.transform.position, TP.transform.rotation);


				}
			}

		}
			

	}
}
