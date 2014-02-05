using UnityEngine;
using System.Collections;

// this script inherits from Blockly.cs instead of just MonoBehaviour
// so it also has access to all the functions inside Blockly.cs! wow!

// all Blockly *functions* start with the word "Blockly"...
// BlocklyMove(), BlocklyTurn(), BlocklyDetectWall()

public class SolutionLab : Blockly {

	// FixedUpdate is called every X seconds... "X" is defined in Edit >> Project Settings >> Time
	void FixedUpdate () {
		// LAB CHALLENGE: use *ONLY* if() statements and Blockly_ functions
		// within the FEWEST lines of code possible to solve the maze!
	
		// "follow left hand wall" trick
		BlocklyMove (transform.forward * 2f); 						// always move forward
		if (BlocklyDetectWall ( transform.forward, 1f ) ) { 		// ASK: is there a wall in front of me?
			BlocklyTurn (90f); 										// if yes, then turn right, so I'm touching the wall with my left hand
		} else if ( !BlocklyDetectWall ( -transform.right, 1f ) ) { // ASK: is there NOT a wall to the left of me?
			BlocklyTurn (-90f); 									// if yes, then turn left and follow that wall
		}
		
	}
}
