using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _IdleState : PlayerBehavior {
	public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    public override void Update() {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded) {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
			{	
				//Chance State To Jump
				moveDirection.y = jumpSpeed;

			}

			if (Input.GetKey(KeyCode.LeftShift))
			{	
				speed = 12.0f;
			}

			if (Input.GetKeyUp(KeyCode.LeftShift))
			{
				speed = 6.0f;
			}

            
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
