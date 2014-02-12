using UnityEngine;
using System.Collections;

public class TenPrint : MonoBehaviour {

	int counter = 0;

	public int lineLength = 20;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// to get a random WHOLE number that's either 0 or 1, feed it 0-2
		int randomNumber = Random.Range (0, 2);

		if (randomNumber == 0) {
			GetComponent<TextMesh>().text += "wow ";
		} else { // is what will if the randomNumber is 1
			GetComponent<TextMesh>().text += "doge ";
		}

		// increment counter
		counter = counter + 1;
		if (counter > lineLength) {
			GetComponent<TextMesh>().text += "\n";
			counter = 0;
		}

	}
}







