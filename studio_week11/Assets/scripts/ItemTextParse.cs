using UnityEngine;
using System.Collections;

public class ItemTextParse : MonoBehaviour {

	public TextAsset textFile; // assign both in Inspector
	public Transform itemPrefab;

	// Use this for initialization
	void Start () {
		StartCoroutine ( ParseAndGenerate() );
	}
	
	// we use a coroutine because doing stuff with strings is usually computationally expensive,
	// especially if we have a lot of string data to dig through
	IEnumerator ParseAndGenerate() {
		// make sure we can access the text file data at all
		Debug.Log ( textFile.text );

		// clean-up platform-dependent line breaks
		string cleanedTextData = textFile.text.Replace ("\r", "");
		// split up the text data into different lines
		string[] lines = cleanedTextData.Split ( "\n" [0] );
		
		// for each line, split it along the commas, and parse it
		foreach (string line in lines) {
			// "var" = "variable", tells C# to figure out what you normally would've put there, it's a shortcut
			// but it won't always work because it won't always figure it out
			var newItem = Instantiate ( itemPrefab, Random.insideUnitSphere * 10f, Quaternion.identity) as Transform;
			// split each line along the commas
			string[] data = line.Split ( "," [0] ); 
			
			// set the name of our item... "name" is a string, so it's okay
			newItem.name = data[0]; 
			// Unity doesn't know that data[1] is a number; we have to tell it to PARSE / convert it to a number
			newItem.transform.localScale = new Vector3( 1f, float.Parse ( data[1] ), 1f);
			
			yield return 0; // we could wait a frame each line to make sure there's no framerate probs
		}
		
	}

}
