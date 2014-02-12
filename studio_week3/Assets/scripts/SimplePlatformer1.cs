using UnityEngine;
using System.Collections;

/// <summary>
/// VERSION 1 of a simple platformer script!
/// This is NOT framerate independent! See "Time.deltaTime" for more info.
/// This script is also missing a bunch of other stuff... see the other SimplePlatformer_ scripts.
/// </summary>
public class SimplePlatformer1 : MonoBehaviour {

	public float moveSpeed = 0.25f; // movement speed, in units per frame
	public float turnSpeed = 3f; // turnspeed, in degrees per frame

	bool jumped = false;
	float jumpStrength = 0f; // see section "JUMPING"
	const bool useSmoothJump = false;

	// TODO: this script is not framerate independent? (see Time.deltaTime)

	// Update is called once per frame
	// ... but if we changed this to FixedUpdate(), then it would run with physics and it WOULD be framerate independent

	void Update () {
		// first, store a temporary REFERENCE to the CharacterController, so
		// that we don't have to keep typing "GetComponent<CharacterController>()"
		// over and over and over...
		CharacterController ctrl = GetComponent<CharacterController>();

		// TODO: disable air control?

		// ================================================================
		// SIMPLE MOVEMENT
		// reminder: "&&" means AND = *all* things must be true 
		// 			 "||" means OR = *at least* one thing must be true
		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow) ) 
		{
			ctrl.Move ( transform.forward * moveSpeed * Time.deltaTime);
		} 
		else if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow) ) 
		{
			ctrl.Move ( -transform.forward * moveSpeed * Time.deltaTime);
		}

		// ================================================================
		// TURNING
//		if (Input.GetKey ( KeyCode.A ) || Input.GetKey (KeyCode.LeftArrow) ) 
//		{
//			transform.Rotate (0f, -turnSpeed * Time.deltaTime, 0f);
//		}
//		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow) ) 
//		{
//			transform.Rotate (0f, turnSpeed * Time.deltaTime, 0f);
//		}

		transform.Rotate (0f, Input.GetAxis ("Horizontal") * Time.deltaTime * 10f, 0f);

		// ================================================================
		// JUMPING
		// first, apply gravity
		ctrl.Move ( Physics.gravity * 0.015f);
		// why "0.015f"? it's what we call a "magic number", just some unexplained value we decided to use.
		// ... usually, you will want to AVOID magic numbers, especially when collaborating.
		
		// next, detect jump inputs and fire if standing on ground
		if (Input.GetKey (KeyCode.Space) && ctrl.isGrounded == true ) // if you removed "isGrounded" check, you could "flap"!
		{
			if (!useSmoothJump) {
				ctrl.Move (transform.up * 7f); 
			} else {
				jumped = true;
				jumpStrength = 0.2f;
			}
		}

		// here, saying just "useSmoothJump" is like saying "useSmoothJump == true"
		// we could also just say "jumped" if we wanted to, too
		if (useSmoothJump && jumped == true) {
			jumpStrength += Time.deltaTime;
			ctrl.Move (transform.up * jumpStrength); 
			if (jumpStrength > 0.5f)
				jumped = false;
		}


	} // closes Update() definition
} // closes class definition
