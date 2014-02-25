using UnityEngine;
using System.Collections;

public class Wanderer : MonoBehaviour {

	public Vector3 destination = Vector3.zero;
	public float wanderRange = 10f;

	// Use this for initialization
	void Start () {
		
	}
	
	void FixedUpdate () {
		GetComponent<Rigidbody>().AddForce ( Vector3.Normalize (destination - transform.position), ForceMode.VelocityChange );

		destination = new Vector3( Random.Range (-wanderRange, wanderRange), 0f, Random.Range (-wanderRange, wanderRange) );
	}
}







