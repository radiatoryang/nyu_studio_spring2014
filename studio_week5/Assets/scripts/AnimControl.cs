using UnityEngine;
using System.Collections;

public class AnimControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		// IS THIS NPC MOVING?
		// IF YES: play a walking animation
		// IF NO: play the idle animation
		
		if ( transform.parent.rigidbody.velocity.magnitude > 2f ) {
			GetComponent<Animation>().CrossFade ( "PandaWalk" );
		} else {
			animation.CrossFade ( "PandaIdle" );
		}
	}
}
