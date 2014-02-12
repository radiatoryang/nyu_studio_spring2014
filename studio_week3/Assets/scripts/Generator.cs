using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {

	// references to our blueprints / PREFABS... assign in inspector
	public Transform skyscraperPrefab, shoppingMallPrefab;

	int buildingCount = 0;

	// Update is called once per frame
	void Update () {

		// only do this if we have less than 500 buildings already
		// (if we dont set a limit, then it will spawn FOREVER and might make Unity crash!)
		if ( buildingCount < 500 )
		{
			// the core of this logic is the same as TenPrint.cs: "randomly do either X or Y"
			float randomNumber = Random.Range (0f, 10f);

			if ( randomNumber < 5.0f)
			{
				// spawn a skyscraper
				// count your parentheses and commas!!!!
				Instantiate (skyscraperPrefab, new Vector3( Random.Range (-100f, 100f), 0f, Random.Range (-100f, 100f) ), Quaternion.identity );
			}
			else 
			{
				// spawn a shopping mall
				Instantiate (shoppingMallPrefab, new Vector3( Random.Range (-100f, 100f), 0f, Random.Range (-100f, 100f) ), Quaternion.identity );
			}

			// increment counter
			buildingCount = buildingCount + 1;

		} // closes out if(buildingCount)

	} // closes out Update ();

} // close out our class definition
