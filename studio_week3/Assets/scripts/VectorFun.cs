using UnityEngine;
using System.Collections;

public class VectorFun : MonoBehaviour {

	// public Vector3 pointA, pointB;
	public Transform pointA, pointB;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F) ) {
			// float distance = Vector3.Distance( pointB.position, pointA.position );
			float distance = Vector3.Magnitude ( pointB.position - pointA.position );


			Debug.Log ( "THESE TWO POINTS ARE THIS MANY APART: " + distance.ToString () );
		}
	}
}




