using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnRescue : MonoBehaviour {

	public Ladder Ldr;
	public SnapLadder SL;
	public Animation Anim;
	void Start () {
		
		SL = GameObject.Find("Short Ladder").GetComponent<SnapLadder>();
		Anim = GetComponent<Animation>();

	}
	
	// Update is called once per frame
	void Update () {
		
		

	}
}
