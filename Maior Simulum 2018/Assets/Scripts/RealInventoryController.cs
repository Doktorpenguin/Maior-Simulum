using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RealInventoryController : MonoBehaviour {
	
	public Image Icon;
	public Item item;
	void Start () {
		
	}
	
	void Update () {
		
	}

	void AddItem (Item newItem)
	{
		item = newItem;

		Icon = newItem.itemIcon;
		Icon.enabled = true;
	}

	void ClearSlot ()
	{
		item = null;

		Icon = null;
		Icon.enabled = false;

	}
}
