using UnityEngine;
using System.Collections;

public class RandomQuaternion : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler ( Random.Range (0, 4) * 90f, Random.Range (0f, 360f), Random.Range(0f, 360f) );
		Vector3 eulerAngles = transform.rotation.eulerAngles;
	}
}
