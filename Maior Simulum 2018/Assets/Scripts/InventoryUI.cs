using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {

	RealInventoryController[] slots;
	public Transform Parents;
	void Start () {
		

		slots = Parents.GetComponentsInChildren<RealInventoryController>();
	}
	
	void Update () {
		
	}

	void UpdateUI ()
	{

		for (int i = 0; i < slots.Length; i++)
		{
			
		}

	}
}
