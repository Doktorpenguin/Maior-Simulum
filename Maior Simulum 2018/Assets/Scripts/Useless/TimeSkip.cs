using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSkip : MonoBehaviour {

	public GameObject  Sun;
	void Start () {
		
	}
	
	void Update () {
		
	}

	public void ChanceTime () {

		Debug.Log("BOOP");
		Sun.transform.Rotate(135, -30, 0);

	}
}
