using UnityEngine;
using System.Collections;

public class HighScore : MonoBehaviour {

	// this script will remember a high score across playthroughs / level restarts,
	// until we quit the game... if you want to remember stuff even when the player
	// quits the game, then use "PlayerPrefs" (look it up in Unity docs)

	// "static" keyword tells Unity to PERSIST this variable across level changes
	// because, technically, this now lives inside the codebase and not inside a level!
	static int highScore = 0;
	
	// Update is called once per frame
	void Update () {
		// press R to reload level, so we can test whether it remembers the score
		if (Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel ( 2 );
		}
		
		// our amazing game mechanic
		if (Input.GetKeyDown (KeyCode.Space) ) {
			// Time.time gives you ENTIRE TIME the game has been running; Time.timeSinceLevelLoad doesn't.
			highScore = Mathf.RoundToInt (Time.timeSinceLevelLoad);
		}
		
		// display our current score
		GetComponent<TextMesh>().text = highScore.ToString ();
	}
}
