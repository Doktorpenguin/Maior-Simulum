using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New House", menuName = "Create House")]
public class Builder : ScriptableObject {

	//The Building's Health.
	public int Health;
	//How many resources does the player need to build this and how much will be removed from the Player.
	public int Cost;
	//How many Pawns can "fit" in these house.
	public int Size;
	//What the house looks like.
	public GameObject Prefab;
	//The Transparent Preview.
	public GameObject TOP;
	//What kind of resources does this building need.
	//Legend: 0 = Wood, 1 = Stone & 2 = Iron.
	public int resourceCostType;


}
