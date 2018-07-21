using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour {

	public Text text;
	public int woodRSC;
	void Start () {



	}
	
	void Update () {
		
		if (woodRSC > 0)
		{
			text.text = woodRSC.ToString();
		}
		
	}
}
