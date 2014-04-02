using UnityEngine;
using System.Collections;

public class BallFeel : MonoBehaviour {

	public Transform ball1, ball2; // assign in inspector

	// Use this for initialization
	void Start () {
		StartCoroutine ( BallSwap() );
	}
	
	IEnumerator BallSwap () {
		Debug.Log ("the coroutine started");
		yield return 0; // tells coroutine to wait one frame
		Debug.Log ("1 frame elapsed");
		yield return new WaitForSeconds( 1f ); // tells coroutine to pause for 1 second
		Debug.Log ("1 second elapsed");
		
		// infinite loop where balls keep swapping positions
		while (true) {
			float time = 0f;
			Vector3 origBall1Pos = ball1.position;
			Vector3 origBall2Pos = ball2.position;	
			bool didBallHitAlready = false;
			
			while ( time < 1f ) {
				time += Time.deltaTime;
				ball1.position = Vector3.Lerp( origBall1Pos, origBall2Pos, time );
				ball2.position = Vector3.Lerp( origBall2Pos, origBall1Pos, time );	
				// check if the balls are intersecting; if so, play a ball hit
				if (time >= 0.48f && time <= 0.52f && didBallHitAlready == false) {
					didBallHitAlready = true;
					audio.Play ();
					// yield return StartCoroutine ( ScreenShake() );
					StartCoroutine ( ScreenShake () );
				}
										
				yield return 0; // wait one frame
			}
			
		}
		
	}
	
	IEnumerator ScreenShake () {
		float time = 0.25f;
		Vector3 origCamPos = Camera.main.transform.position;
		while ( time > 0f ) { // as long as time > 0, SHAKE THE SCREEN
			time -= Time.deltaTime;
			Camera.main.transform.position = origCamPos 
											 + Camera.main.transform.up * Mathf.Sin (time * 100f)
											 + Camera.main.transform.right * Mathf.Sin (time * 113f);
			yield return 0; // wait a frame
		}
		Camera.main.transform.position = origCamPos; // reset camera back to original position
	}
	
}










