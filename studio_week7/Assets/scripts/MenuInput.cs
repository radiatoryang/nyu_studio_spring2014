using UnityEngine;
using System.Collections;

public class MenuInput : MonoBehaviour {

	public KeyCode buttonToPush = KeyCode.Space; // expose to inspector
	public string nextLevel = "typeInSceneNameHere"; // expose to inspector
	
	// Update is called once per frame
	void Update () {
		if ( Input.GetKeyDown ( buttonToPush ) ) {
			Application.LoadLevel ( nextLevel );
		}
	}
}
