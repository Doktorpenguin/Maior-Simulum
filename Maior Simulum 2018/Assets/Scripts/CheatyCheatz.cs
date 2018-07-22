using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatyCheatz : MonoBehaviour {

	private InventoryController IC;
	public CharacterControls CC;
	void Start () {
		IC = GetComponent<InventoryController>();
		CC = GetComponent<CharacterControls>();
	}
	
	void Update () {
		
		//When 0 is pressed the player receives 100 wood
		if (Input.GetKeyDown(KeyCode.Keypad0))
		{
			IC.woodRSC += 100;
			Debug.Log("~@CHEAT ACTIVATED: 100 Wood Added@~");
		}

		if (Input.GetKeyDown(KeyCode.Keypad8))
		{
			CC.health += 1;
		}

		else if (Input.GetKeyDown(KeyCode.Keypad2))
		{
			CC.health -= 1;
		}
	}
}
