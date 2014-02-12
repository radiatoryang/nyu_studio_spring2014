using UnityEngine;
using System.Collections;

public class NPCBot : MonoBehaviour {

	// this var will hold our reference to the Transform comp. on the player gameObject
	public Transform player;
	public float speed = 5f;
	public float followDistance = 5f;

	public float turnSpeed = 10f;

	public float bounceHeight = 0.3f;
	public float bounceSpeed = 50f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// make the bot follow the player, but only if the player is further than 5 units away
		if ( Vector3.Distance (transform.position, player.position) > followDistance ) 
		{
			transform.position += Vector3.Normalize(player.position - transform.position) * Time.deltaTime * speed;

			// use the sine wave to make the bot bounce
			// (since this is inside the if() block, the bot will bounce ONLY when moving!)
			transform.position += transform.up * ( Mathf.Sin (Time.time * bounceSpeed) * bounceHeight );

			// a "clamping" function, make sure the bot never goes below y=0
//			if ( transform.position.y < 0f) 
//			{
//				transform.position = new Vector3( transform.position.x, 0f, transform.position.z );
//			}
		}

		// make the bot look at the player
		Vector3 finalFacing = (player.position - transform.position).normalized;
		// smooth the bot's facing toward the player with linear interpolation!
		transform.forward = Vector3.Lerp ( transform.forward, finalFacing, Time.deltaTime * turnSpeed );

	}
}














