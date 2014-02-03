using UnityEngine;
using System.Collections;

public class Adventure : MonoBehaviour {

	// piece of memory that remembers our location
	string currentRoom = "Lobby";

	// "boolean" is true OR false, that's it
	bool hasStudentID = false;

	// Use this for initialization
	void Start () {
	
	}

	// "switch()"
	
	// Update is called once per frame
	void Update () {
		// if I declare a variable inside Update(),
		// then I can ONLY use this variable inside Update() !!
		// "buffer" is a staging area to prepare data
		string textBuffer = "You are currently in: " + currentRoom;
		// "concatenate"

		// "if" is like a yes / no question you ask Unity
		// if the expression is "true", then the code will run!
		if ( currentRoom == "Lobby" ) {
			// typing "\n" means "new line"
			textBuffer += "\nYou see the NYU Poly security guard. \"Close the door\", she says.";
			// the line of code below is the SAME as the line of code above
			// textBuffer = textBuffer + "\nYou sed the NYU Poly security guard.";

			textBuffer += "\npress [W] to go to elevators";
			textBuffer += "\npress [S] to go outside";

			// textBuffer += "\npress [W] to go to elevators\npress [S] to go outside";

			// textBuffer += "\npress [W] to go to elevators" +
			//	          "\npress [S] to go outside";

			// DETECT INPUT
			// if player pushes W...
			if ( Input.GetKeyDown (KeyCode.W) ) {
				currentRoom = "Elevators";
			}
			if ( Input.GetKeyDown (KeyCode.S) ) {
				currentRoom = "Outside";
			}
		} else if ( currentRoom == "Elevators" ) { 
			textBuffer += "\nYou're waiting.";

			if ( hasStudentID == false) {
				textBuffer += "\nYou can't go in without your ID card, though...";
			} else {
				textBuffer += "\nYou swipe your student ID and the guard smiles.";

				// TODO: add choice to take elevator up to 8th floor
			}

		} else if ( currentRoom == "Outside" ) {
			textBuffer += "\nIT IS REALLY COLD WHAT IS WRONG WITH YOU";
			textBuffer += "\npress [S] to go back INSIDE, LIKE RIGHT NOW";

			textBuffer += "\n(oh hey you found your student ID!)";
			hasStudentID = true;

			if (Input.GetKeyDown (KeyCode.S))
				currentRoom = "Lobby";

			// the 3 lines below are EXACTLY THE SAME as the 2 lines above
//			if (Input.GetKeyDown (KeyCode.S)) {
//				currentRoom = "Lobby";
//			}
		}


		// lets "render out" our text buffer and display it on-screen
		GetComponent<TextMesh>().text = textBuffer;
	}
}
