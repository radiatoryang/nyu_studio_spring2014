using UnityEngine;
using System.Collections;

public class NotMayaUI : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
	
		// rotate camera around object if user holds down right-click and moves mouse horizontally
		if ( Input.GetMouseButton (1) ) {
			Camera.main.transform.RotateAround ( Vector3.zero, Vector3.up, Input.GetAxis ("Mouse X") );
		}
		
	}
}
