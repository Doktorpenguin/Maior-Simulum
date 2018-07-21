using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCheat : MonoBehaviour {

	public MeshCollider Col;
	void Start () {
		
		Col = GetComponent<MeshCollider>();

	}
	
	void Update () {
		
	}

	public void OnTriggerEnter ()
	{
		Col.enabled = false;
	}

	public void OnTriggerExit ()
	{
		Col.enabled = true;
	}
}
