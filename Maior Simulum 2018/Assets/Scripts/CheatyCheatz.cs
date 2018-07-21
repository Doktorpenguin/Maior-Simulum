using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatyCheatz : MonoBehaviour {

	public InventoryController IC;
	void Start () {
		IC = GetComponent<InventoryController>();
	}
	
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.Keypad0))
		{
			IC.woodRSC += 100;
			Debug.Log("~@CHEAT ACTIVATED: 100 Wood Added@~");
		}
	}
}
