using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

	//Setting Up Variables...
	public float xMod = 15f;
	public float zMod = 15f;
	//REMOVE THIS IS RUNNING VARIABLE IT'S USELESS
	public bool isRunning = false;
	public Camera cam;
	public GameObject treeImpactFX;
	//public PlayerBuilding PB;
	void Start () {
		//On Game Start run these...
		Cursor.lockState = CursorLockMode.Locked;

	}
	
	void Update () {
		//All The Code For The Player Controls Moving, Attacking, etc..
#region Controls
		//Update This...
		//Movement Controls...
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * xMod;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * zMod;

		transform.Translate(x, 0, 0);
		transform.Translate(0, 0, z);

		//Sprinting, When Shift is held down the player moves faster
		if (Input.GetKey(KeyCode.LeftShift))
		{
			xMod = 60f;
			zMod = 60f;

			isRunning = true;
		}

		//When The Player lets go of shift their speed returns to normal
		else if (Input.GetKeyUp(KeyCode.LeftShift))
		{
			xMod = 15f;
			zMod = 15f;

			isRunning = false;
		}

		//If your mouse is locked this will let it "Escape"
		if (Input.GetKeyDown(KeyCode.Escape))
		{

			if (Cursor.lockState == CursorLockMode.Locked)
			{ Cursor.lockState = CursorLockMode.None;}

		}
		#endregion

		RaycastHit hit;
		float range = 4.5f;
		
		if (Input.GetMouseButtonDown(0))
		{	
			//If the player left clicks while having their mouse unlocked then lock their mouse
			if (Cursor.lockState == CursorLockMode.None)
			{Cursor.lockState = CursorLockMode.Locked;}
			//When The Player Presses Mouse 0 (Left Mouse Button) The Script Will Check If He's Looking At A Tree Then Figure Out What Tree It Is And "Attack it"
			if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
			{
				
				TreeScript Target = hit.transform.GetComponent<TreeScript>();
				if (Target != null) {
					Target.Punch(1);
				}

				else {

				}
				GameObject treeFX = Instantiate(treeImpactFX, hit.point, Quaternion.LookRotation(hit.normal));
				Destroy(treeFX, 2f);
			}

		}

	}
}
