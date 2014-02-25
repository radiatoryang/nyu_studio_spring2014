using UnityEngine;
using System.Collections;

public class HoopTrigger : MonoBehaviour {

	public Camera camera1;
	public Camera camera2;
	public Camera camera3; // assign in inspector

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// OnTriggerEnter is called when a collider enters this trigger;
	// either this trigger the thing entering it MUST HAVE A RIGIDBODY (at least one)
	void OnTriggerEnter(Collider other) {
		if ( other.tag == "GreenBall" )
		{
			Destroy(other.gameObject);
			Time.timeScale = 0.1f;
			camera3.enabled = true;
		}
	}

}
