using UnityEngine;
using System.Collections;

// DO NOT EDIT THIS SCRIPT!!! (see SolutionDemo.cs for example usage)

// this is an "abstract" class that can ONLY be inherited from...
// ... so make a new script, and tell it to inherit from Blockly instead of MonoBehaviour!
public abstract class Blockly : MonoBehaviour {
	int actionNumber = 0;

	public void BlocklyTurn ( float yawDegrees ) {
		transform.Rotate (0f, yawDegrees, 0f);
		Debug.Log (actionNumber.ToString () + ": BlocklyTurn( " + yawDegrees.ToString () + ")" );
		actionNumber++;
	}

	public void BlocklyMove ( Vector3 direction ) {
		GetComponent<CharacterController>().Move ( direction );
		GetComponent<CharacterController>().Move ( Physics.gravity ); // apply gravity
		Debug.Log (actionNumber.ToString () + ": BlocklyMove" + direction.ToString () );
		actionNumber++;
	}

	public bool BlocklyDetectWall ( Vector3 direction, float distance ) {
		return Physics.Raycast ( transform.position, direction.normalized, distance );
		Debug.Log (actionNumber.ToString () + ": BlocklyDetectWall" + direction.ToString () );
		actionNumber++;
	}
}
