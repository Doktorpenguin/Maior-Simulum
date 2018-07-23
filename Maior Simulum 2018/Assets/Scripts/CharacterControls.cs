using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(CharacterController))]
public class CharacterControls : MonoBehaviour {

    //@@@@@REMINDER@@@@@ This Script is only for controls not player stats like speed.
	private float speed = 7.0F;
    private float sprintSpeed = 14.0f;
    private float jumpSpeed = 8.0F;
    private float gravity = 20.0F;

    //Stats n' Stats...
    public float health;
    private float maxHealth = 10f;
    public float hunger;
    private float maxHunger = 100;
    public float hungerRate = 0.5f;
    public float stamina;
    private float maxStamina = 30;

    private bool isDead = false;
    public GameObject DeathText;
    public Image healthBar;
    public Image hungerBar;
    public Image staminaBar;

    public Camera cam;
    public GameObject timpactFX;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {

        health = maxHealth;
        hunger = maxHunger;
        stamina = maxStamina;

        InvokeRepeating("HungerDecay", 0, hungerRate);

    }
    
    void Death()
    {
        Debug.Log("You are Dead");
        DeathText.SetActive(true);
    }

    void Update() {

        if (isDead)
        {
            Death();
        }

#region Health/Hunger/Stamina

        healthBar.fillAmount = health / maxHealth;
        hungerBar.fillAmount = hunger / maxHunger;
        staminaBar.fillAmount = stamina / maxStamina;

        if (health > maxHealth)
        {
            health = 10;
        }

        if (hunger == 0)
        {
            isDead = true;
        }

#endregion


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
				speed = sprintSpeed;
			}

			if (Input.GetKeyUp(KeyCode.LeftShift))
			{
				speed = 7.0f;
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
		
#region Controls
        //What to do when the player press the left mouse button.
		if (Input.GetMouseButtonDown(0))
		{	
			//If the player left clicks while having their mouse unlocked then lock their mouse
			if (Cursor.lockState == CursorLockMode.None)
			{Cursor.lockState = CursorLockMode.Locked;}
			//When The Player Presses Mouse 0 (Left Mouse Button) The Script Will Check If he hit something and if so what it hit.
			if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
			{   
                //If the player clicks on a tree...
				if (hit.transform.gameObject.tag == "Tree")
                {
                    //Get the script for the tree that has just been hit
                    TreeScript Target = hit.transform.GetComponent<TreeScript>();
                    //@@REMINDER@@ Replace attack number with Attack variable
                    //Run the function that handles what to do when the tree is punched.
				    Target.Punch(1);
                    //Spawns a particle system wherever the player clicked.
                    GameObject treeFX = Instantiate(timpactFX, hit.point, Quaternion.LookRotation(hit.normal));
                    //Then Destroys said particle system.
                    Destroy(treeFX, 1f);
                }

                if (hit.transform.gameObject.tag == "Item")
                {
                    ItemBehavior Target = hit.transform.gameObject.GetComponent<ItemBehavior>();
                }
				
			}

		}
#endregion
        //Movement Stuff
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    void HungerDecay ()
    {

        hunger--;
        if (hunger < 0)
        {
            hunger = 0;
        }

        if (isDead)
        {
            CancelInvoke();
        }

    }
}