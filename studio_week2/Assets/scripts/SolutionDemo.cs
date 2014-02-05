using UnityEngine;
using System.Collections;

// this script inherits from Blockly.cs instead of just MonoBehaviour
// so it also has access to all the functions inside Blockly.cs! wow!

// all Blockly *functions* start with the word "Blockly"...

public class SolutionDemo : Blockly {

	// FixedUpdate is called every X seconds... "X" is defined in Edit >> Project Settings >> Time
	void FixedUpdate () {

		// let's make a variable to hold the number five
		int five = 5;

		// move forward
		BlocklyMove( GetComponent<Transform>().forward );
	
		// if we detect a wall that is 2 units in front of us, then turn 90 degrees to the right
		if ( BlocklyDetectWall ( transform.forward, 2f ) ) {
			BlocklyTurn ( 90f );
		}

	}
}
