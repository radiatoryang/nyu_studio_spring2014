using UnityEngine;
using System.Collections;

public class HelloWorld : MonoBehaviour {

	// "public" is a keyword that lets other parts of your code see this variable
	// "public" also exposes the variable to the Unity inspector
	public string message = "Bonjour monde";

	// Use this for initialization
	void Start () {
		Debug.Log ( "Hello World! :)" );

		// intent: display "Hello World" in French in our 3D Text
		GetComponent<TextMesh>().text = message;

	}
	
	// Update is called once per frame
	// Happens every frame
	void Update () {
	
	}
}
