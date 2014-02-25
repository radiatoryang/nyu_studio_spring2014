using UnityEngine;
using System.Collections;
using System.Collections.Generic; // we need THIS LINE to use a structure called "Lists"


public class God : MonoBehaviour {

	public Wanderer blueprint; // assign in Inspector
	public List<Wanderer> friendList = new List<Wanderer>();

	public int maxFriends = 100;

	// Use this for initialization
	void Start () {

//		int friendCount = 0;
//
//		while ( friendCount < maxFriends ) {
//			SpawnFriend ();
//			friendCount++; // same as typing "friendCount += 1" AKA "friendCount = friendCount +1"
//		}

		for ( int friendCount = 0; friendCount < maxFriends; friendCount++ ) {
			if (friendCount < 10) {
				// invite my first 10 friends to the party
			}

			friendList.Add ( SpawnFriend () );
		}

	}


	Wanderer SpawnFriend () {
		return Instantiate ( blueprint,
		             new Vector3( Random.Range (-5f, 5f), 2f, Random.Range (-5f, 5f) ),
		             Quaternion.Euler(0f, Random.Range(0f, 360f), 0f) 
		       ) as Wanderer;
	}

	
	// Update is called once per frame
	void Update () {

		// using a spacebar to "rally" our friends
		if ( Input.GetKey (KeyCode.Space ) ) 
		{
			foreach ( Wanderer friend in friendList ) {
				friend.destination = new Vector3(100f, 0f, 0f);
			}

			// single-out our THIRD friend and tell them to go somewhere else
			friendList[2].destination = new Vector3(-100f, 0f, 0f);
		}

		// use a mouse to "command" our friends
		// first, initalize the RAY and RAYCASTHIT variables
		if ( Input.GetMouseButton(0) ) 
		{
			Ray ray = Camera.main.ScreenPointToRay ( Input.mousePosition );
			RaycastHit rayHit = new RaycastHit(); // a blank container to hold forensics info

			if ( Physics.Raycast (ray, out rayHit, 1000f ) )
			{
				foreach ( Wanderer friend in friendList ) {
					friend.destination = rayHit.point;
				}
			}
		}
	}







}
