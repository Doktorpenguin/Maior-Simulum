using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterControls : MonoBehaviour {

    //@@@@@REMINDER@@@@@ This Script is only for controls not player stats like speed.
	private float speed = 7.0F;
    private float jumpSpeed = 8.0F;
    private float gravity = 20.0F;
    public Camera cam;
    public GameObject timpactFX;
    private Vector3 moveDirection = Vector3.zero;
    void Update() {
#region Movement
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded) 
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
            

            if (Input.GetKey(KeyCode.LeftShift))
			{	
				speed = 12.0f;
			}

			if (Input.GetKeyUp(KeyCode.LeftShift))
			{
				speed = 6.0f;
			}

        }
#endregion

            if (Input.GetKeyDown(KeyCode.KeypadEnter))
		{
            if (Cursor.lockState == CursorLockMode.None)
            {   Cursor.lockState = CursorLockMode.Locked;
            }

			else if (Cursor.lockState == CursorLockMode.Locked)
			{   Cursor.lockState = CursorLockMode.None;
            }

		}

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
				if (hit.transform.gameObject.tag == "Tree")
                {
                    TreeScript Target = hit.transform.GetComponent<TreeScript>();
                    //Replace attack number with Attack variable
				    Target.Punch(1);
                    GameObject treeFX = Instantiate(timpactFX, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(treeFX, 1f);
                }
				
			}

		}

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}